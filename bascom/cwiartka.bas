$regfile = "m328pdef.dat"
$crystal = 16000000
$baud = 9600                                                ' predko�� transmisji
$hwstack = 128                                              ' rozmiar stosu sprz�towego
$swstack = 128                                              ' rozmiar stosu
$framesize = 128                                            ' rozmiar ramki
Const Debugging = 0                                         '1 info o programie  2 - przerwanie na seriala
'********************* Konfiguracja dodatkowych bibliotek
'AVR-DOS config
$include "Config_MMC.bas"                                   'Konfiguracja karty SD
$include "Config_AVR-DOS.BAS"                               'Biblioteka AVR-DOS
'********************* Konfiguracja wej�� i wyj��
Open "comc.4:9600,8,n,1" For Output As #1                   'SDA
Open "comc.5:9600,8,n,1" For Input As #2                    'SCL


'********************* Deklaracje zmiennych

'Dim L As Byte

'********************* Deklaracje zmiennych karty SD
Dim Blad_sd As Bit
Dim Zapisano As Bit
Dim B As Word
Dim Czas As Word
Dim Tft As Byte , Pc As Byte , Pc_init As Bit
Dim No_left As Byte , No_right As Byte , No_kjs As Byte
Dim Fallstart_left As Byte , Fallstart_right As Byte
Dim Czas_start_lewa As Word , Czas_start_prawa As Word
Dim Czas_meta_lewa As Word , Czas_meta_prawa As Word
Dim Czas_meta_lewa_flaga As Bit , Czas_meta_prawa_flaga As Bit
Dim Et_rt_lewa As Word , Et_rt_prawa As Word
Dim Czas_start_lewa_flaga As Bit , Czas_start_prawa_flaga As Bit
Dim Kjs_flaga As Bit , Cwiartka_flaga As Bit

Dim Ustawienie_flaga_bufor As Byte , Ustawienie_flaga As Byte
Dim L As String * 1 , P As String * 1

'********************* Deklaracje podprogram�w
Declare Sub Write_to_sd_cwiartka()
Declare Sub Write_to_sd_kjs()


'********************* Deklaracje Alias�w
Config Portd.7 = Output
Set Portd.7
Sd_dioda Alias Portd.7
Config Pinb.0 = Output , Pinb.1 = Output , Pind.6 = Output , Pinc.0 = Output , Pinc.1 = Output , Pinc.2 = Output
Led1 Alias Portb.0
Led2 Alias Portb.1
Led3 Alias Portd.6
Led4 Alias Portc.0
Led5 Alias Portc.1
Led6 Alias Portc.2

Reset Led1
Reset Led2
Reset Led3
Reset Led4
Reset Led5
Reset Led6



Config Pind.2 = Input , Pind.3 = Input
Config Int0 = Rising                                        'meta_lewa
Config Int1 = Rising                                        'meta_prawa
'Config Int0 = Change                                        'meta_lewa
'Config Int1 = Change                                        'meta_prawa
Meta_lewa Alias Pind.2
Meta_prawa Alias Pind.3
Config Pind.5 = Input                                       'pcint21
Start_lewa Alias Pind.5
Config Pind.4 = Input                                       'pcint20
Start_prawa Alias Pind.4

'Set Portd.5                                                 'pullup
'Set Portd.4
'Reset Portd.2
'Reset Portd.3

'1 oznacza przeciecie linii lub odlaczona bramke
'0 mamy sygnal z nadajnika

'################PCINTY##############
Enable Pcint2
Enable Int0
Enable Int1
'Pcmsk2 = &B00100000
Pcmsk2 = &B00110000                                         'rejestry i inne pierdoly wektory
On Pcint2 Isr_start                                         'start lewa+prawa
On Int0 Isr_meta_lewa                                       'meta lewa+prawa
On Int1 Isr_meta_prawa


Config Timer1 = Timer , Prescale = 64
Load Timer1 , 250
On Timer1 1ms                                               'odliczanie 1 ms

'********************* Konfiguracja SD/MMC
'MMC -->ATMega32       atmega328p
'DATA3 -> PORTB.4      PORTB.2             SS
'DI    -> PORTB.5      PORTB.3             MOSI

'CLK   -> PORTB.7      PORTB.5             SCK
'DATA0 -> PORTB.6      PORTB.4             MISO

'********************* Warto�ci pocz�tkowe
Zapisano = 0
Blad_sd = 0


No_left = 100
No_right = 100
No_kjs = 100



Enable Interrupts
Print "hello world"                                         'czy�� ekran


Reset Sd_dioda                                              'zapala
Wait 1
Set Sd_dioda                                                'gasi
Wait 1

'(
If Start_lewa = 0 And Start_prawa = 0 Then                  'nie podlaczone
Set Sd_dioda
Else
Reset Sd_dioda
End If
')

Do


'Print #1 , "dim=dim-5" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff); 'ustawienie sciemniania
'Print #1 , "t1.txt=" ; Chr(&H22) ; "Ello " ; Chr(&H22) ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'wyslanie textu
   Pc = Inkey()
   Tft = Inkey(#2)
   If Pc = 32 Then                                          'jesli SHIFT IN HEX 0F (15) to kontrola PC i blokujemy wyswietlacz
      Pc_init = 1
      Reset Sd_dioda
      Print #1 , "page pc" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
   Elseif Pc = 27 Then
      Pc_init = 0
      Set Sd_dioda
      Print #1 , "page page0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
   End If

   If Tft = 32 Then
      Set Sd_dioda
      #if Debugging = 1
         Print "wchodze do cwiartki"
      #endif
      Gosub Cwiartka

   Elseif Tft = "K" Then

      #if Debugging = 1
         Print "wchodze do KJS"
      #endif
      Gosub Kjs

   End If


'############## do okna powitalnego do ustawiania bramek ##################

   Ustawienie_flaga.0 = Start_lewa
   Ustawienie_flaga.1 = Start_prawa
   Ustawienie_flaga.2 = Meta_lewa
   Ustawienie_flaga.3 = Meta_prawa

   If Tft = "U" Then
      Ustawienie_flaga_bufor = 16
   End If


   If Ustawienie_flaga <> Ustawienie_flaga_bufor Then
      Print #1 , "n0.val=n0.val+1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
      Print #1 , "va1.val=" ; Ustawienie_flaga ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
      Ustawienie_flaga_bufor = Ustawienie_flaga
   End If


'(
   K = Inkey(#2)
   If K > 0 Then
   Print K
   End If
')
'Waitms 100

'Call Write_to_sd
'Toggle Sd_dioda
'Print #1 , "drugi com"
Loop
End



'***********************  Obs�uga cwiartki ***********************
Cwiartka:
   Do
      Tft = Inkey(#2)




      If No_left = 100 Or No_right = 100 Then               'obsluga nr startowych
         Do
            Tft = Inkey(#2)

                        If Tft = "L" Then
               No_left = Waitkey(#2)


            Elseif Tft = "P" Then
               No_right = Waitkey(#2)

            End If

         Loop Until No_left < 100 And No_right < 100 Or Tft = 27
         Waitms 100
         Print #1 , "b3.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' zaczerniam przycisk start
         Print #1 , "t0.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
         Print #1 , "t1.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony

      End If



      If Tft = "S" Then                                     'sekwencja startowa
         If No_left = 100 Or No_right = 100 Then            'jesli nie wpisany nr
                                                             'wroc do page wpisywania numerow

            Kjs_flaga = 0
         'Elseif No_left = 0 And No_right = 0 Then           'jesli zawodnicy maja obydwaj nr 0
                                                             'wroc do page wpisywania numerow

         Else
            Cwiartka_flaga = 1                              'rozpoczynamy odliczanie
            Czas = 0
            Fallstart_left = 0
            Fallstart_right = 0
            Czas_start_lewa_flaga = 0
            Czas_start_prawa_flaga = 0
            Czas_meta_lewa_flaga = 0
            Czas_meta_prawa_flaga = 0
            Czas_start_lewa = 0
            Czas_start_prawa = 0
            Czas_meta_lewa = 0
            Czas_meta_prawa = 0
            Et_rt_prawa = 0
            Et_rt_lewa = 0


            Print #1 , "tsw b3,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
            Print #1 , "b3.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
            Print #1 , "tsw b4,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk CANCEL
            Print #1 , "b4.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
            Print #1 , "b1.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk lewa nr i prawa
            Print #1 , "tsw b1,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "b2.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "tsw b2,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "tsw b0,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk wroc
            Print #1 , "b0.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);

            Load Timer1 , 250                               'wlaczamy timer1
            Enable Timer1

            #if Debugging = 1
               Print "sekwencja startowa"
            #endif

            Set Led1
            Set Led2
            Do
               Tft = Inkey(#2)
               'Reset Led1
               Select Case Czas
'################ ODLICZANIE

                  Case 1 To 3999 :
                     Set Led1
                     Set Led2
                  Case 4000 :
                     Reset Led1
                     Reset Led2
                     Set Led3
                  Case 4500 :
                     Reset Led3
                     Set Led4                               'zapal pierwsza lamp
'################ tu zaczyna sie start od 5 sekundy
                  Case 5000 :
                     Reset Led3
                     Reset Led4
                     Set Led5
                     Set Led6

'################# tu sobie mozna cos wymyslic co potem
                  Case 5001 To 9000 :
                     If Fallstart_left = 1 Then
                        Set Led1
                     End If

                     If Fallstart_right = 1 Then
                        Set Led2
                     End If

                  Case 9001 :
                     Reset Led1
                     Reset Led2
                     Reset Led3
                     Reset Led4
                     Reset Led5
                     Reset Led6                             'zapal pierwsza lampe

                  Case 12000 To 24999 :
                     If No_left = 0 Then
                        If Czas_meta_prawa_flaga = 1 Then
                           Tft = "C"
                        End If
                     Elseif No_right = 0 Then
                        If Czas_meta_lewa_flaga = 1 Then
                           Tft = "C"
                        End If
                     Elseif No_right <> 0 And No_left <> 0 Then
                        If Czas_meta_prawa_flaga = 1 And Czas_meta_lewa_flaga = 1 Then
                           Tft = "C"
                        End If
                     End If
                  Case 25000 : Tft = "C"                    ' po 25 - 5 sekundach wyjdz z cwiartki
               End Select


            Loop Until Tft = "C"                            'or zakonczony przejazd dopisac





            #if Debugging = 1
               Waitms 100
               Print "zakonczyl wyscig";
               Print " Fallstart_left: " ; Fallstart_left ; " Fallstart_right: " ; Fallstart_right
               Print "Lewa: " ; Czas_start_lewa ; " Prawa: " ; Czas_start_prawa
               Print "Lewa_meta: " ; Czas_meta_lewa ; " Prawa_meta: " ; Czas_meta_prawa
               Waitms 100
            #endif

            Disable Timer1
            Cwiartka_flaga = 0
            Reset Led1
            Reset Led2


            If Fallstart_left = 0 And Czas_start_lewa > 5000 Then
               Czas_start_lewa = Czas_start_lewa - 5000
               Print #1 , "n0.val=" ; Czas_start_lewa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Else
               Czas_start_lewa = 0
               Print #1 , "n0.val=" ; Czas_start_lewa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            End If

            If Fallstart_right = 0 And Czas_start_prawa > 5000 Then
               Czas_start_prawa = Czas_start_prawa - 5000
               Print #1 , "n1.val=" ; Czas_start_prawa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Else
               Czas_start_prawa = 0
               Print #1 , "n1.val=" ; Czas_start_prawa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            End If

            If Czas_meta_lewa = 0 Then
               Et_rt_lewa = 0
            Else
               Et_rt_lewa = Czas_meta_lewa - 5000
               If Fallstart_left = 0 Then
                  Czas_meta_lewa = Et_rt_lewa - Czas_start_lewa
               Else
                  Czas_meta_lewa = 0
               End If
            End If



            If Czas_meta_prawa = 0 Then
               Et_rt_prawa = 0
            Else
               Et_rt_prawa = Czas_meta_prawa - 5000
               If Fallstart_right = 0 Then
                  Czas_meta_prawa = Et_rt_prawa - Czas_start_prawa
               Else
                  Czas_meta_prawa = 0
               End If
            End If


            'Czas_meta_lewa = Et_rt_lewa - Czas_start_lewa
            'Czas_meta_prawa = Et_rt_prawa - Czas_start_prawa


            Print #1 , "n2.val=" ; Czas_meta_lewa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Print #1 , "n3.val=" ; Czas_meta_prawa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Print #1 , "n4.val=" ; Et_rt_lewa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Print #1 , "n5.val=" ; Et_rt_prawa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START


            Reset Led1
            Reset Led2
            Call Write_to_sd_cwiartka
            Print #1 , "tsw b3,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
            Print #1 , "b3.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
            Print #1 , "tsw b4,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk CANCEL
            Print #1 , "b4.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
            Print #1 , "b1.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk lewa nr i prawa
            Print #1 , "tsw b1,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "b2.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "tsw b2,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Print #1 , "tsw b0,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk wroc
            Print #1 , "b0.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Czas = 0
            No_left = 100
            No_right = 100
            Print #1 , "t0.txt=" ; Chr(&H22) ; "wpisz " ; Chr(&H22) ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'wyslanie textu
            Print #1 , "t0.pco=63813" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
            Print #1 , "t1.txt=" ; Chr(&H22) ; "wpisz " ; Chr(&H22) ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'wyslanie textu
            Print #1 , "t1.pco=63813" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
            'page do wpisywania numerow

            Reset Led1
            Reset Led2
         End If
      End If



'Print "pc: " ; Pc ; " tft: " ; Tft ; " podprogram cwiartka"
'Wait 1
   Loop Until Tft = 27 Or Pc = 27
   Print "wychodze z cwiartki"
   No_left = 100
   No_right = 100
   Ustawienie_flaga_bufor = 16                              'do odczytu bramek w glownym menu wyswietlacza
Return

'***********************  Obs�uga KJS #########################################
Kjs:

   Print #1 , "tsw b1,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
   Print #1 , "b1.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
   Print #1 , "tsw b2,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk cancel
   Print #1 , "b2.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk cancel
   Do
      Tft = Inkey(#2)

      If No_kjs = 100 Then                                  'obsluga nr startowych
         Do
            Tft = Inkey(#2)
            If Tft = "k" Then
               No_kjs = Waitkey(#2)

            End If
         Loop Until No_kjs < 100 Or Tft = 27
         Waitms 100

         #if Debugging = 1
            Print "nr startowy: " ; No_kjs
         #endif


         Print #1 , "tsw b0,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
         Print #1 , "b0.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk START
         Print #1 , "b1.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' zaczerniam przycisk start
         'Print #1 , "t0.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
         'Print #1 , "t1.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
      End If

      If Meta_lewa = 1 Then
         Set Led1
         Set Led2
         Else
         Reset Led1
         Reset Led2
      End If


      If Tft = "R" Then
         Print #1 , "tsw b1,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
         Print #1 , "b1.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
         Print #1 , "tsw b1,1" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' odblokujemy przycisk cancel
         Print #1 , "b2.pco=0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk cancel
         Cwiartka_flaga = 0
         Kjs_flaga = 1
         Czas = 0
         Czas_start_lewa_flaga = 0
         Czas_meta_lewa = 0
         Czas_meta_lewa_flaga = 0

         #if Debugging = 1
            Print "start"
         #endif
         Set Led5
         Set Led6

         Do
            Tft = Inkey(#2)
            Select Case Czas
               Case 5000 :
                  Reset Led5
                  Reset Led6
            End Select

         Loop Until Tft = "C" Or Czas_meta_lewa > 0 Or Czas > 60000       'or zakonczony przejazd dopisac

         #if Debugging = 1
            Print "czas: " ; Czas_meta_lewa
         #endif

         Print #1 , "t0.txt=" ; Chr(&H22) ; "wpisz " ; Chr(&H22) ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'wyslanie textu
         Print #1 , "t0.pco=63813" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       'kolor zmienay na czerwony
         Print #1 , "tsw b1,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
         Print #1 , "b1.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk START
         Print #1 , "tsw b2,0" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk cancel
         Print #1 , "b2.pco=65535" ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);       ' blokujemy przycisk cancel
         Kjs_flaga = 0

         If Tft <> "C" Or Czas < 60000 Then
            Print #1 , "n0.val=" ; Czas_meta_lewa ; Chr(&Hff) ; Chr(&Hff) ; Chr(&Hff);
            Call Write_to_sd_kjs

         End If

         Disable Timer1
         No_kjs = 100
         Reset Led1
      End If


   Loop Until Tft = 27 Or Pc = 27



   Ustawienie_flaga_bufor = 16                              'do odczytu bramek w glownym menu wyswietlacza
Return






'***********************  Obs�uga zapisu na SD



Sub Write_to_sd_cwiartka()                                  ''()
   Local Errorcode As Byte
   Gbdriveerror = Driveinit()
   If Gbdriveerror = 0 Then
      Errorcode = Initfilesystem(1)
      If Errorcode <> 0 Then
         Blad_sd = 1
      Else
         Reset Sd_dioda                                     'Zapala diod� LED
         Open "cwiartka.txt" For Append As #3               'otw�rz plik pomiar.txt aby dopisa� dane
         Write #3 , "L" , No_left , Fallstart_left , Czas_start_lewa , Czas_meta_lewa , Et_rt_lewa,
         Write #3 , "P" , No_right , Fallstart_right , Czas_start_prawa , Czas_meta_prawa , Et_rt_prawa,       'zapisz dane: data, czas , odczyt temperatury
         Flush #3                                           'zapisz bufor pliku na karcie SD
         Close #3                                           'zamknij kana� transmisji sprz�towego urz�dzenia
         Blad_sd = 0                                        'ustaw zmienna na 0
         Set Sd_dioda                                       'zga� diod� LED
      End If
   Else
      Reset Sd_dioda                                        'zapala diod� LED
      Blad_sd = 1
   End If
End Sub                                                     ' Write_to_sd()
'*********************** Podprogram okre�laj�cy kiedy dokona� pomiar�w oraz zapisu na SD

Sub Write_to_sd_kjs()                                       ''()
   Local Errorcode As Byte
   Gbdriveerror = Driveinit()
   If Gbdriveerror = 0 Then
      Errorcode = Initfilesystem(1)
      If Errorcode <> 0 Then
         Blad_sd = 1
      Else
         Reset Sd_dioda                                     'Zapala diod� LED
         Open "KJS.txt" For Append As #3                    'otw�rz plik pomiar.txt aby dopisa� dane
         Write #3 , No_kjs , Czas_meta_lewa
         Flush #3                                           'zapisz bufor pliku na karcie SD
         Close #3                                           'zamknij kana� transmisji sprz�towego urz�dzenia
         Blad_sd = 0                                        'ustaw zmienna na 0
         Set Sd_dioda                                       'zga� diod� LED
      End If
   Else
      Reset Sd_dioda                                        'zapala diod� LED
      Blad_sd = 1
   End If
End Sub                                                     ' Write_to_sd()
'*********************** Podprogram okre�laj�cy kiedy dokona� pomiar�w oraz zapisu na SD

Isr_start:
   If Cwiartka_flaga = 1 Then
      If Start_lewa = 1 Then                                   'przeciecie startu lewa
         Set Led1

         If Czas < 5000 Then                                   'fallstart
            Fallstart_left = 1
            Czas_start_lewa_flaga = 1
         Elseif Czas >= 5000 And Czas_start_lewa_flaga = 0 Then
            Czas_start_lewa = Czas                             '
            Czas_start_lewa_flaga = 1                          'blokada przed wrzuceniem kolejnego czasu
         End If

         #if Debugging = 2
            Print "start_lewa = 1 ";
         #endif

      Else

         Reset Led1
      End If

      If Start_prawa = 1 Then                                  'przeciecie startu prawa
         Set Led2
         If Czas < 5000 Then                                   'fallstart
            Fallstart_right = 1
            Czas_start_prawa_flaga = 1                         'blokada przed wrzuceniem kolejnego czasu
         Elseif Czas >= 5000 And Czas_start_prawa_flaga = 0 Then
            Czas_start_prawa = Czas                            '
            Czas_start_prawa_flaga = 1                         'blokada przed wrzuceniem kolejnego czasu
         End If


         #if Debugging = 2
            Print "start_prawa = 1 ";
         #endif
      Else
         Reset Led2

      End If


   End If

   If Start_lewa = 1 Then
   Set Led1
   Else
   Reset Led1
   End If

   If Start_prawa = 1 Then
   Set Led2
   Else
   Reset Led2
   End If


   #if Debugging = 2
      Print " "
   #endif
Return

Isr_meta_lewa:

   If Meta_lewa = 1 Then
      If Cwiartka_flaga = 1 Then
         If Czas_start_lewa_flaga = 1 And Czas_meta_lewa_flaga = 0 Then

            Czas_meta_lewa = Czas
            Czas_meta_lewa_flaga = 1

         End If
      Elseif Kjs_flaga = 1 Then
         If Czas_start_lewa_flaga = 0 Then
            Load Timer1 , 250                               'wlaczamy timer1
            Enable Timer1
            Czas_start_lewa_flaga = 1


         Elseif Czas > 5000 And Czas_start_lewa_flaga = 1 And Czas_meta_lewa_flaga = 0 Then
            Czas_meta_lewa = Czas
            Czas_meta_lewa_flaga = 1

         End If                                             ' tutaj licz czas dla kjs

   '(   Elseif Kjs_flaga = 0 And Cwiartka_flaga = 0 Then
         If Meta_lewa = 1 Then
         Set Led1
         Set Led2
         Else
         Reset Led1
         Reset Led2
         End If
')
      End If


      #if Debugging = 2
         Print "meta_lewa = 1 ";
      #endif
   End If
Return


Isr_meta_prawa:

   If Meta_prawa = 1 Then
'
      If Cwiartka_flaga = 1 Then
         If Czas_start_prawa_flaga = 1 And Czas_meta_prawa_flaga = 0 Then

            Czas_meta_prawa = Czas
            Czas_meta_prawa_flaga = 1

         End If


         #if Debugging = 2
            Print "meta_prawa = 1 ";
         #endif
      End If
   End If




Return



'############# liczenie 1 ms ##################
1ms:
   Load Timer1 , 250
   Incr Czas
Return
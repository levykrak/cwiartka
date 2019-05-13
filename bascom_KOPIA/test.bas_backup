$regfile = "m328pdef.dat"
$crystal = 16000000
$baud = 9600                                                ' predkoœæ transmisji
$hwstack = 128                                              ' rozmiar stosu sprzêtowego
$swstack = 128                                              ' rozmiar stosu
$framesize = 128                                            ' rozmiar ramki
'********************* Konfiguracja dodatkowych bibliotek
'AVR-DOS config
$include "Config_MMC.bas"                                   'Konfiguracja karty SD
$include "Config_AVR-DOS.BAS"                               'Biblioteka AVR-DOS
'********************* Konfiguracja wejœæ i wyjœæ
Open "comc.4:9600,8,n,1" For Output As #1                   'SDA
Open "comc.5:9600,8,n,1" For Input As #2                    'SCL

'********************* Deklaracje zmiennych

Dim L As Byte

'********************* Deklaracje zmiennych karty SD
Dim Blad_sd As Bit
Dim Zapisano As Bit
Dim B As Word
Dim Czas As Long
'********************* Deklaracje podprogramów
Declare Sub Settime(byval S1 As Byte , Byval M1 As Byte , Byval H1 As Byte , Byval D1 As Byte , Byval Month1 As Byte)       '***** ustawianie czasu
Declare Sub Gettime()                                       'pobieranie czasu
Declare Sub Wysw_godz                                       'wyœwietlanie czasu
Declare Sub Write_to_sd()
Declare Sub Pomiar
Declare Sub Ds_odczyt
'********************* Deklaracje Aliasów
Config Portd.7 = Output
Set Portd.7
Sd_dioda Alias Portd.7


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
Pcmsk2 = &B00110000
On Pcint2 Isr_start                                         'start lewa+prawa
On Int0 Isr_meta                                            'meta lewa+prawa
On Int1 Isr_meta


Config Timer1 = Timer , Prescale = 64
Load Timer1 , 250
On Timer1 1ms                                               'odliczanie 1 ms

'********************* Konfiguracja SD/MMC
'MMC -->ATMega32       atmega328p
'DATA3 -> PORTB.4      PORTB.2             SS
'DI    -> PORTB.5      PORTB.3             MOSI

'CLK   -> PORTB.7      PORTB.5             SCK
'DATA0 -> PORTB.6      PORTB.4             MISO

'********************* Wartoœci pocz¹tkowe
Zapisano = 0
Blad_sd = 0



Enable Interrupts
Print "hello world"                                         'czyœæ ekran


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

'Wait 2
'Call Write_to_sd
'Toggle Sd_dioda
'Print #1 , "drugi com"
Loop
End



Cwiartka:

Return

'***********************  Obs³uga zapisu na SD
Sub Write_to_sd()                                           ''()
   Local Errorcode As Byte
   Gbdriveerror = Driveinit()
   If Gbdriveerror = 0 Then
      Errorcode = Initfilesystem(1)
      If Errorcode <> 0 Then
         Blad_sd = 1
      Else
         Reset Sd_dioda                                     'Zapala diodê LED
         Open "pomiar.txt" For Append As #2                 'otwórz plik pomiar.txt aby dopisaæ dane
         Write #2 , "To Ja" "cos tam" "Diskfree = " "uolele"       'zapisz dane: data, czas , odczyt temperatury
         Flush #2                                           'zapisz bufor pliku na karcie SD
         Close #2                                           'zamknij kana³ transmisji sprzêtowego urz¹dzenia
         Blad_sd = 0                                        'ustaw zmienna na 0
         Set Sd_dioda                                       'zgaœ diodê LED
      End If
   Else
      Reset Sd_dioda                                        'zapala diodê LED
      Blad_sd = 1
   End If
End Sub                                                     ' Write_to_sd()
'*********************** Podprogram okreœlaj¹cy kiedy dokonaæ pomiarów oraz zapisu na SD


Isr_start:
   If Start_lewa = 1 Then
      Print "start_lewa = 1 ";
   End If
   If Start_prawa = 1 Then
      Print "start_prawa = 1 ";
   End If

   Print " "

Return

Isr_meta:
   If Meta_lewa = 1 Then
      Print "meta_lewa = 1 ";
   End If
   If Meta_prawa = 1 Then
      Print "meta_prawa = 1 ";
   End If
   Print " "
Return


'############# liczenie 1 ms ##################
1ms:
   Load Timer1 , 250
   Incr Czas
Return
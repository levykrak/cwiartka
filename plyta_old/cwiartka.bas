$regfile = "m8def.dat"                                      'informuje kompilator o pliku 'dyrektyw mikrokontrolera
$crystal = 16000000                                         'informuje kompilator o czêstotliwoœci oscylatora taktuj¹cego mikrokontroler
$baud = 9600



Config Lcd = 16 * 2                                         'konfigurujemy wystwietlacz
Config Lcdpin = Pin , Db4 = Portc.2 , Db5 = Portc.3 , Db6 = Portc.4 , Db7 = Portc.5 , E = Portc.1 , Rs = Portc.0
Cursor Off Noblink

Dim Czas As Long
Dim Czas_kjs As String * 10
Dim Zwolnienie As Bit , Odczekaj As Bit , Wybor As Bit
Dim Lewa_fall As Bit , Prawa_fall As Bit
Dim Lewa_fall_temp As Bit , Prawa_fall_temp As Bit
Dim Zwolnienie_lewa_rt As Bit , Zwolnienie_prawa_rt As Bit
Dim Zwolnienie_lewa_et_rt As Bit , Zwolnienie_prawa_et_rt As Bit
Dim Rt_lewa As Long , Rt_prawa As Long , Et_rt_lewa As Long , Et_rt_prawa As Long
Dim Et_rt_lewa_str As String * 10 , Et_rt_prawa_str As String * 10

Dim Start_sw As Word
Dim Przelacznik_sw As Word

Start_sw = 1
Przelacznik_sw = 1
Zwolnienie = 1
Odczekaj = 0

Config Pind.5 = Output                                      'konfigurujemy port jako wyjscie przekaznika
Config Pind.6 = Output                                      'konfigurujemy port jako wyjscie przekaznika
Config Pind.7 = Output                                      'konfigurujemy port jako wyjscie przekaznika
Config Pinb.0 = Output                                      'konfigurujemy port jako wyjscie przekaznika
Config Pinb.1 = Output                                      'konfigurujemy port jako wyjscie przekaznika
Config Pind.2 = Input , Pind.3 = Input
Config Int0 = Falling
Config Int1 = Falling
Config Timer1 = Timer , Prescale = 64
Load Timer1 , 250
Config Adc = Single , Prescaler = Auto , Reference = Avcc


Enable Interrupts
Enable Int0
Enable Int1
Enable Timer1
Start Adc


On Int0 Lewa_przerw
On Int1 Prawa_przerw
On Timer1 1ms

Przekaznik1 Alias Portd.5                                   'alias
Przekaznik2 Alias Portd.6                                   'alias
Przekaznik3 Alias Portd.7                                   'alias
Przekaznik4 Alias Portb.0                                   'alias
Przekaznik5 Alias Portb.1                                   'alias
Lewa Alias Pind.2
Prawa Alias Pind.3

Cls
Lcd " Sie wlaczam"
Wait 1
Print "F-body Klub Polska"
Print "wykonanie: "
Print "Hardware : LeVy"
Print "Software : Nogal"
Print "   "

'#################  petla glowna ###############
Do

   Start_sw = Getadc(6)                                     'zwalilem schemat i przyciski obslugiwane sa na przetworniku
   Przelacznik_sw = Getadc(7)
   Waitms 100

   If Przelacznik_sw = 0 Then
    Wybor = 1
'    Cls
'    Lcd "      1/4"
    Gosub Cwiartka
   Else
    Wybor = 0
    Locate 1 , 1
    Lcd "      KJS       "
    Gosub Kjs
   End If

Loop
End

'############# podprogramy   ##################

Lewa_przerw:
   If Wybor = 0 Then                                        'kjs
      If Zwolnienie = 1 Then                                'kjs
         If Lewa = 0 Then
            Start Timer1
'            Print "poszedl"  'informacja dla kompa ze ruszyl
            Przekaznik1 = 1                                 'sygnalizacja swietlna ze pojechal
            Przekaznik2 = 1
            Zwolnienie = 0
       End If
      Elseif Odczekaj = 1 Then
         Stop Timer1
         Zwolnienie = 0
         Reset Przekaznik1
         Reset Przekaznik2
      End If                                                'koniec kjs
   Else                                                     'w innym przypadku cwiartka
      Lewa_fall_temp = 1
      If Zwolnienie_lewa_rt = 1 Then
         Rt_lewa = Czas
         Zwolnienie_lewa_rt = 0
      Elseif Zwolnienie_lewa_et_rt = 1 Then
         Et_rt_lewa = Czas
         Zwolnienie_lewa_et_rt = 0
      End If


   End If

Return


Prawa_przerw:
   Prawa_fall_temp = 1
   If Zwolnienie_prawa_rt = 1 Then
      Rt_prawa = Czas
      Zwolnienie_prawa_rt = 0
   Elseif Zwolnienie_prawa_et_rt = 1 Then
      Et_rt_prawa = Czas
      Zwolnienie_prawa_et_rt = 0
   End If


Return



'############# liczenie 1 ms ##################

1ms:
   Load Timer1 , 250
   Incr Czas
Return

'######################cwiartka################
'##############################################

Cwiartka:
'ustawiamy swiatla na zolte

   If Lewa = 0 Then                                         'migamy choinka jak koles zajechal za daleko
      Set Przekaznik2
   End If

   Waitms 200
   Reset Przekaznik2

'ustawiamy swiatla na zolte

   If Prawa = 0 Then                                        'migamy choinka jak koles zajechal za daleko
      Set Przekaznik1
   End If

   Waitms 200
   Reset Przekaznik1

If Start_sw = 0 Then
   Lewa_fall_temp = 0
   Prawa_fall_temp = 0
   Lewa_fall = 0
   Prawa_fall = 0
   Czas = 0
   Zwolnienie_lewa_et_rt = 0
   Zwolnienie_prawa_et_rt = 0

   Cls
   Lcd "ODLICZAM"
   Set Przekaznik1
   Set Przekaznik2
   Wait 2
   Przekaznik3 = 1
   Waitms 500
   Przekaznik4 = 1
   Waitms 500
   Przekaznik5 = 1

   Lcd "  START"
                              'poszli

   If Lewa_fall_temp = 1 Then                               'fallstart lewa
      Print "fallstart lewa"
      Lewa_fall = 1
   Else
      Zwolnienie_lewa_rt = 1
   End If

   If Prawa_fall_temp = 1 Then                              ' fallstart prawa
      Print "fallstart prawa"
      Prawa_fall = 1
   Else
      Zwolnienie_prawa_rt = 1
   End If

   Czas = 0
   Start Timer1


   While Czas < 6000                                        'kilka spowalniaczy wyzwalania
   Wend

   Zwolnienie_lewa_et_rt = 1
   Zwolnienie_prawa_et_rt = 1

   Print "lewa " ; Rt_lewa
   Print "prawa " ; Rt_prawa

   While Et_rt_lewa = 0 Or Et_rt_prawa = 0 And Czas < 25000
   Wend

   Stop Timer1
   Locate 1 , 1

      If Lewa_fall = 0 Then
         Et_rt_lewa_str = Str(et_rt_lewa)
         Et_rt_lewa_str = Format(et_rt_lewa_str , "0.000")
         Lcd "L: ET+RT: " ; Et_rt_lewa_str
         Print " lewa ET+RT:" ; Et_rt_lewa ; ", RT:" ; Rt_lewa ; "  "
      Else
         Lcd "L: FALLSTART    "
      End If

   Lowerline

      If Prawa_fall = 0 Then

         Et_rt_prawa_str = Str(et_rt_prawa)
         Et_rt_prawa_str = Format(et_rt_prawa_str , "0.000")
         Lcd "P: ET+RT: " ; Et_rt_prawa_str
         Print "prawa ET+RT:" ; Et_rt_prawa ; ", RT:" ; Rt_prawa ; "  "
      Else
         Lcd "P: FALLSTART    "
      End If

   Wait 1

   Rt_lewa = 0
   Rt_prawa = 0
   Et_rt_lewa = 0
   Et_rt_prawa = 0
   Przekaznik5 = 0
   Przekaznik4 = 0
   Przekaznik3 = 0
   Przekaznik2 = 0
   Przekaznik1 = 0


End If

Return


'#####################################
'##############KJS###################

Kjs:

'ustawiamy swiatla na zolte

If Lewa = 0 Then                                            'migamy choinka jak koles zajechal za daleko
   Set Przekaznik1
   Set Przekaznik2
   End If
   Waitms 400
   Reset Przekaznik1
   Reset Przekaznik2

'dolozyc obsluge startu i zresetowac timer1
If Start_sw = 0 Then
   Lowerline
   Lcd "START           "
   Set Przekaznik5
   Stop Timer1
   Zwolnienie = 1
   Odczekaj = 0
   Czas = 0

   While Lewa = 1                                           'kilka spowalniaczy wyzwalania
   Wend

   Locate 2 , 7
   Lcd "NAQRWIAJ!!"
   Wait 3
   Odczekaj = 1
   Reset Przekaznik5


                                             'zabezpieczenie od migania bramy
   While Lewa = 1
   Wend
   Zwolnienie = 0

   Czas_kjs = Str(czas)                                     'przesylanie wynikow do kompa
   Czas_kjs = Format(czas_kjs , "0.000")
   Print "KJS:" ; Czas_kjs ; "/" ; Checksum(czas_kjs)
   Odczekaj = 0
   Locate 2 , 1
   Lcd Czas_kjs ; " [s]       "

   Wait 1
End If

Return

'####################################
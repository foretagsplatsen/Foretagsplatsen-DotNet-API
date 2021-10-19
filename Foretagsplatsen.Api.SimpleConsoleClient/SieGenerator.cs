namespace Foretagsplatsen.Api.SimpleConsoleClient
{
	public class SieGenerator
	{
		static public string Generate(string companyId, string year)
		{
			return string.Concat(@"
#FLAGGA 0
#KSUMMA
#FORMAT PC8
#SIETYP 4
#ORGNR ", companyId, @"
#PROGRAM ""SPCS Bokf�ring Windows"" 2.21f
#GEN ", year, @"0224
#FNR D:\BTESTW\SIETEST
#FNAMN ""SmallValidSie""
#ADRESS ""Wolters Kluwer Scandinavia AB"" ""Emigrantv�gen 2G"" ""414 63 G�teborg"" 031-7751700
#RAR 0 ", year, @"0101 ", year, @"1231
#KONTO 1010 Kassa
#KONTO 1020 Postgiro
#KONTO 1040 Checkkonto
#KONTO 1050 ""�vriga bankr�kningar""
#KONTO 1120 ""Aktier och andelar""
#KONTO 1130 ""Obligationer v�rdepapper""
#KONTO 1210 Kundfordringar
#KONTO 1220 Kundv�xlar
#KONTO 1230 Factoringfordringar
#KONTO 1290 ""V�rderegl. kundfordringar""
#KONTO 1310 ""F�rutbetalda hyror""
#KONTO 1340 ""F�rutbetalda r�ntor""
#KONTO 1350 ""Upplupen hyra""
#KONTO 1360 ""Upplupen r�nta""
#KONTO 1390 ""�vriga interimsfordringar""
#KONTO 1410 ""Fordring hos anst�lld""
#KONTO 1411 Resef�rskott
#KONTO 1412 ""�vriga f�rskott""
#KONTO 1420 ""Fordring hos n�rst�ende""
#KONTO 1430 ""Fordran hos leverant�r""
#KONTO 1450 Skattefordringar
#KONTO 1470 ""Ing�ende merv�rdeskatt""
#KONTO 1480 ""Fordran merv�rdeskatt""
#KONTO 1490 ""V�rderegl div kortfr ford""
#KONTO 1510 Varulager
#KONTO 1530 ""Produkter i arbete""
#KONTO 1550 ""P�g. arbete tj�nstef�reta""
#KONTO 1551 ""P�g. arbete byggf�retag""
#KONTO 1580 ""F�rskott leverant�r""
#KONTO 1611 ""Sp�rrkonto riksbanken mfl""
#KONTO 1621 ""Aktier, sv dotterf�retag""
#KONTO 1622 ""Aktier, utl dotterf�retag""
#KONTO 1625 ""Aktier, andra sv f�retag""
#KONTO 1626 ""Aktier, andra utl f�retag""
#KONTO 1630 Obligationer
#KONTO 1650 ""L�ngfristiga fordringar""
#KONTO 1670 Depositioner
#KONTO 1690 ""V�rderegl l�ngfr fordr""
#KONTO 1710 Patent
#KONTO 1720 Hyresr�tt
#KONTO 1730 Goodwill
#KONTO 1740 ""Balanserade utgifter""
#KONTO 1810 Maskiner
#KONTO 1819 ""V�rdem maskiner""
#KONTO 1820 Inventarier
#KONTO 1829 ""V�rdem inventarier""
#KONTO 1830 Byggnadsinventarier
#KONTO 1839 ""Byggnadsinv v�rdem""
#KONTO 1840 Bilar
#KONTO 1849 ""Bilar v�rdem""
#KONTO 1880 ""Konst+�vr ej avskrb.tillg""
#KONTO 1910 Byggnader
#KONTO 1919 ""Byggnader v�rdem""
#KONTO 1940 Mark
#KONTO 1950 ""Tomt markomr obebyggd""
#KONTO 1980 Markanl�ggning
#KONTO 1989 ""Markanl�ggning v�rdem""
#KONTO 2010 ""Skulder under indrivning""
#KONTO 2110 Leverant�rsskulder
#KONTO 2120 Leverant�rsv�xlar
#KONTO 2210 Skatteskulder
#KONTO 2250 ""Skuld prelimin�rskatt""
#KONTO 2300 Interimskulder
#KONTO 2310 ""Upplupen l�n""
#KONTO 2320 ""Upplupna sem.l�ner""
#KONTO 2331 ""Upplupna sociala avgifter""
#KONTO 2340 ""Upplupna r�ntekostnader""
#KONTO 2350 ""F�rutbet hyresint�kter""
#KONTO 2360 Garantiskulder
#KONTO 2370 ""Upplupen AMF-avgift""
#KONTO 2410 ""Utg. merv�rdeskatt - 25 %""
#KONTO 2411 ""Utg. merv�rdeskatt - 21 %""
#KONTO 2412 ""Utg. merv�rdeskatt - 12 %""
#KONTO 2420 ""Merv.skatt egna uttag 25%""
#KONTO 2421 ""Merv.skatt egna uttag 21%""
#KONTO 2422 ""Merv.skatt egna uttag 12%""
#KONTO 2450 ""S�rskild punktskatter""
#KONTO 2480 ""Merv�rdeskatt redov konto""
#KONTO 2510 ""Personalens k�llskatt""
#KONTO 2520 ""Personalens kvarskatt""
#KONTO 2530 Inf�rsel
#KONTO 2550 Kollektivf�rs�kring
#KONTO 2560 Fackavgifter
#KONTO 2590 ""�vriga l�neavdrag""
#KONTO 2610 ""F�rskott fr�n kunder""
#KONTO 2640 L�neskulder
#KONTO 2690 ""�vr kortfr skulder""
#KONTO 2710 ""Avsatt till pension""
#KONTO 2720 Checkkredit
#KONTO 2740 Reversl�n
#KONTO 2750 ""L�n i utl�ndsk valuta""
#KONTO 2794 ""L�n fr�n aktie�gare""
#KONTO 2799 ""�vr l�ngfr skulder""
#KONTO 2813 ""Reserv p�g arbeten""
#KONTO 2820 ""Ack �veravskrivningar""
#KONTO 2860 ""Uppsk belopp uppl.reserv.""
#KONTO 2871 K-surv
#KONTO 2872 L-surv
#KONTO 2873 I-surv
#KONTO 2891 ""�vr obeskatt reserver""
#KONTO 2991 Aktiekapital
#KONTO 2992 Reservfond
#KONTO 2997 ""Balanserad vinst/f�rlust""
#KONTO 2998 ""F�reg�ende �rs resultat""
#KONTO 2999 ""Redovisat resultat""
#KONTO 3011 ""F�rs�ljning momspl - 25 %""
#KONTO 3012 ""F�rs�ljning momspl - 21 %""
#KONTO 3013 ""F�rs�ljning momspl - 12 %""
#KONTO 3014 ""F�rs�ljning momsfri""
#KONTO 3015 ""F�rs�ljning export""
#KONTO 3081 ""L�mnade kassarabatter""
#KONTO 3510 ""F�rs�ljning material""
#KONTO 3590 ""�vriga sidoint�kter""
#KONTO 3610 ""Fakturerat emballage""
#KONTO 3620 Frakt
#KONTO 3621 Expeditionsavgift
#KONTO 3630 ""Fakt tull och spedition""
#KONTO 3631 ""Frakt export""
#KONTO 3632 ""Exp.avgift export""
#KONTO 3650 ""Fakt resekostnader""
#KONTO 3690 ""�vr fakt kostnader""
#KONTO 3720 ""Kursdifferenser r�relsen""
#KONTO 3770 ""�tervunna kundf�rluster""
#KONTO 3780 �resutj�mning
#KONTO 3810 Hyresint�kter
#KONTO 3850 Provisionsint�kter
#KONTO 3880 F�rs�kringsers�ttning
#KONTO 3890 ""�vr ers�ttn och int�kter""
#KONTO 3910 ""Erh�llna statliga bidrag""
#KONTO 3920 ""Erh�llna kommunala bidrag""
#KONTO 3990 ""�vriga erh�llna bidrag""
#KONTO 4010 ""Ink�p material och varor""
#KONTO 4081 ""Erh�llna kassarabatter""
#KONTO 4090 Lager�ndring
#KONTO 4610 ""Legoarbeten, underentrepr""
#KONTO 4910 ""F�r�ndring lager""
#KONTO 5010 ""L�n arbetare/servicepers""
#KONTO 5082 Semesterl�n
#KONTO 5090 ""F�r�ndr sem.l�neskuld""
#KONTO 5210 ""L�ner f�retagsledare""
#KONTO 5220 ""L�ner tj�nstem�n""
#KONTO 5290 ""F�r�ndr sem.l�neskuld""
#KONTO 5300 ""Andra kontanta ers�ttn""
#KONTO 5400 ""Naturaf�rm�n anst�llda""
#KONTO 5410 ""Kostn f�r fri bostad""
#KONTO 5420 ""Kostn fria/subv m�ltider""
#KONTO 5450 ""Kostn f�r fri bil""
#KONTO 5490 ""�vr kostn f�r naturaf�rm""
#KONTO 5521 ""Skattefria trakt Sverige""
#KONTO 5522 ""Skattepl trakt Sverige""
#KONTO 5523 ""Skattefria trakt utland""
#KONTO 5524 ""Skattepl trakt utland""
#KONTO 5531 ""Skattefri bilers�ttning""
#KONTO 5532 ""Skattepl bilers�ttning""
#KONTO 5590 ""�vr kostnadsers�ttningar""
#KONTO 5610 Arbetsgivaravgifter
#KONTO 5631 L�neskatt
#KONTO 5670 ""AMF enl avtal""
#KONTO 5710 Pensionsf�rs�kring
#KONTO 5711 ""Kollektiv pensionsf�rs�kr""
#KONTO 5712 ""Indiv persionsf�rs�kring""
#KONTO 5790 ""�vriga pensionskostnader""
#KONTO 5800 ""Utbildn h�lsov�rd mm""
#KONTO 5890 ""�vr personalsoc verksamh""
#KONTO 6010 Lokalhyra
#KONTO 6050 ""El och v�rme""
#KONTO 6060 Lokaltillbeh�r
#KONTO 6070 ""St�dning av lokalen""
#KONTO 6080 Reparationer
#KONTO 6090 ""�vr lokalkostnader""
#KONTO 6110 ""Hyra maskiner""
#KONTO 6120 ""Hyra inventarier""
#KONTO 6190 ""�vriga hyreskostnader""
#KONTO 6210 El
#KONTO 6280 Vatten
#KONTO 6290 ""�vriga br�nslen""
#KONTO 6410 F�rbrukningsinventarier
#KONTO 6460 F�rbrukningsmaterial
#KONTO 6480 Arbetskl�der
#KONTO 6510 Kontorsmaterial
#KONTO 6550 Trycksaker
#KONTO 6600 ""Reparation och underh�ll""
#KONTO 6730 Redovisningstj�nster
#KONTO 6740 Datakostnader
#KONTO 6750 Konsultarvoden
#KONTO 6780 Advokatkostnader
#KONTO 6790 ""�vr fr�mmande tj�nster""
#KONTO 6810 Telefon
#KONTO 6850 Porto
#KONTO 6911 ""Bilomk drivmedel""
#KONTO 6912 ""Bilomk skatt f�rs�kr""
#KONTO 6913 ""Bilomk reparationer""
#KONTO 6915 ""Bilomk leasingavg""
#KONTO 6990 ""�vr kostn egna transportm""
#KONTO 7010 ""Frakt och transport""
#KONTO 7020 ""Tull- och speditionskost""
#KONTO 7050 Resekostnader
#KONTO 7090 ""�vriga resekostnader""
#KONTO 7110 ""Katalog och prislistor""
#KONTO 7150 F�rs�ljningsprov
#KONTO 7160 ""Kreditf�rs�ljn kostn""
#KONTO 7171 ""Represen avdr gill""
#KONTO 7172 ""Represen ej avdr gill""
#KONTO 7173 ""Vin/sprit ej avdr gill""
#KONTO 7190 ""�vr f�rs�ljningskostnader""
#KONTO 7200 ""Reklam och PR""
#KONTO 7240 ""Utst�lln och m�ssor""
#KONTO 7310 F�retagsf�rs�kringar
#KONTO 7350 Kundf�rluster
#KONTO 7390 ""�vriga riskkostnader""
#KONTO 7410 Styrelsearvoden
#KONTO 7420 Revisionsarvoden
#KONTO 7490 ""�vr f�rvaltningskostn""
#KONTO 7670 ""Tidn tidskrift facklitt""
#KONTO 7681 ""F�reningsavg avdr gill""
#KONTO 7682 ""F�ren avg ej avdr gill""
#KONTO 7691 ""�vr avdr gill kostn""
#KONTO 7692 ""�vr ej avdr gill kostn""
#KONTO 7693 ""L�mnade bidrag och g�vor""
#KONTO 7695 ""Restavg skatter o soc.avg""
#KONTO 7710 ""Vatten och avlopp""
#KONTO 7720 Br�nsle
#KONTO 7730 Belysning
#KONTO 7740 ""Renh�lln och st�dning""
#KONTO 7750 Sotning
#KONTO 7760 ""Rep och underh fastighet""
#KONTO 7770 ""F�rs�kring fastighet""
#KONTO 7791 Fastighetsskatt
#KONTO 7799 ""�vr fastighetskostnader""
#KONTO 7810 ""Res avyttr maskiner/inv""
#KONTO 7820 ""Res avyttr fastigheter""
#KONTO 7861 ""Res avyttr aktier/andelar""
#KONTO 7891 ""F�r�ndr lager f�rdigvaror""
#KONTO 7892 ""F�r�ndr prod i arbete""
#KONTO 7893 ""F�r�ndr p�g arbete""
#KONTO 7911 ""Avskrivn maskiner""
#KONTO 7912 ""Avskrivn inventarier""
#KONTO 7913 ""Avskrivn bygg inv""
#KONTO 7914 ""Avskrivn bilar""
#KONTO 7921 ""Avskrivn byggnader""
#KONTO 7928 ""Avskrivn markanl�ggn""
#KONTO 7933 ""Avskrivn goodwill""
#KONTO 8011 ""Utdeln sv dotterbolag""
#KONTO 8012 ""Utdeln utl dotterbolag""
#KONTO 8015 ""Utdeln andra sv f�retag""
#KONTO 8016 ""Utdeln andra utl f�retag""
#KONTO 8020 R�nteint�kter
#KONTO 8050 ""R�nteint p� kundfordr""
#KONTO 8080 Kursvinster
#KONTO 8090 ""�vr finansiella int�kter""
#KONTO 8120 R�ntekostnader
#KONTO 8150 ""R�ntekostn f�r lev.skuld""
#KONTO 8170 Bankkostnader
#KONTO 8180 Kursf�rluster
#KONTO 8190 ""�vr finansiella kostnader""
#KONTO 8310 ""Vinst f�rs�ljn anl tillg""
#KONTO 8320 ""Tillskott fr aktie�gare""
#KONTO 8390 ""�vr extraord int�kter""
#KONTO 8410 ""F�rlust f�rs�lj anl tillg""
#KONTO 8490 ""�vriga extraordin kostn""
#KONTO 8814 ""Uppl reserv p�g�ende arb""
#KONTO 8820 ""Avskrivn �ver/under plan""
#KONTO 8860 ""Uppl�sn. uppskovsbelopp""
#KONTO 8871 ""Avs till k-surv""
#KONTO 8872 ""Avs till l-surv""
#KONTO 8873 ""Avs till i-surv""
#KONTO 8874 ""�terf�ring surv""
#KONTO 8910 ""�rets skattekostnad""
#KONTO 8940 Vinstdelningsskatt
#KONTO 8999 ""Redovisat resultat""
#KONTO 9999 ""Obs konto""
#IB 0 1010 21500.00
#UB 0 1010 24000.00
#IB 0 1020 26500.00
#UB 0 1020 19450.00
#IB 0 1040 28500.00
#UB 0 1040 112100.00
#IB 0 1050 -4000.00
#UB 0 1050 -4200.00
#IB 0 1120 3500.00
#UB 0 1120 8500.00
#IB 0 1130 785.00
#UB 0 1130 -4215.00
#IB 0 1210 10215.00
#UB 0 1210 105315.00
#IB 0 1220 1700.00
#UB 0 1220 -48300.00
#IB 0 1230 2300.00
#UB 0 1230 10300.00
#IB 0 1290 800.00
#UB 0 1290 -7200.00
#IB 0 1310 1700.00
#UB 0 1310 10200.00
#IB 0 1340 550.00
#UB 0 1340 -7950.00
#IB 0 1350 2300.00
#UB 0 1350 7300.00
#IB 0 1360 1600.00
#UB 0 1360 -11900.00
#IB 0 1390 8500.00
#UB 0 1390 17500.00
#IB 0 1410 3300.00
#UB 0 1410 2800.00
#IB 0 1411 1500.00
#UB 0 1411 10000.00
#IB 0 1412 7000.00
#UB 0 1412 -1500.00
#IB 0 1420 3700.00
#UB 0 1420 3700.00
#IB 0 1430 7800.00
#UB 0 1430 7800.00
#IB 0 1450 -70.00
#UB 0 1450 4930.00
#IB 0 1470 200.00
#UB 0 1470 -4800.00
#IB 0 1480 200.00
#UB 0 1480 8700.00
#IB 0 1490 600.00
#UB 0 1490 -7900.00
#IB 0 1510 5110.00
#UB 0 1510 13610.00
#IB 0 1530 5500.00
#UB 0 1530 -3300.00
#IB 0 1550 2600.00
#UB 0 1550 2900.00
#IB 0 1551 10200.00
#UB 0 1551 10700.00
#IB 0 1580 4200.00
#UB 0 1580 3700.00
#IB 0 1611 3700.00
#UB 0 1611 5200.00
#IB 0 1621 1380.00
#UB 0 1621 380.00
#IB 0 1622 8400.00
#UB 0 1622 7900.00
#IB 0 1625 3500.00
#UB 0 1625 5000.00
#IB 0 1626 5500.00
#UB 0 1626 4000.00
#IB 0 1630 800.00
#UB 0 1630 1000.00
#IB 0 1650 -300.00
#UB 0 1650 -500.00
#IB 0 1670 6952.00
#UB 0 1670 6952.00
#IB 0 1690 701.00
#UB 0 1690 581.00
#IB 0 1710 1015.00
#UB 0 1710 2515.00
#IB 0 1720 185.00
#UB 0 1720 385.00
#IB 0 1730 2820.00
#UB 0 1730 3020.00
#IB 0 1740 7550.00
#UB 0 1740 7050.00
#IB 0 1810 6700.00
#UB 0 1810 5420.00
#IB 0 1819 7711.00
#UB 0 1819 12711.00
#IB 0 1820 2697.00
#UB 0 1820 2897.00
#IB 0 1829 2000.00
#UB 0 1829 4500.00
#IB 0 1830 900.00
#UB 0 1830 4100.00
#IB 0 1839 -2150.00
#UB 0 1839 -2150.00
#IB 0 1840 3700.00
#UB 0 1840 -7200.00
#IB 0 1849 1700.00
#UB 0 1849 1200.00
#IB 0 1880 4000.00
#UB 0 1880 4500.00
#IB 0 1910 1000.00
#UB 0 1910 2500.00
#IB 0 1919 -1700.00
#UB 0 1919 1000.00
#IB 0 1940 4200.00
#UB 0 1940 1500.00
#IB 0 1950 1000.00
#UB 0 1950 1500.00
#IB 0 1980 8100.00
#UB 0 1980 7600.00
#IB 0 1989 3500.00
#UB 0 1989 3500.00
#IB 0 2010 -500.00
#UB 0 2010 -5500.00
#IB 0 2110 -30400.00
#UB 0 2110 -38900.00
#IB 0 2120 -5500.00
#UB 0 2120 -5500.00
#IB 0 2210 -700.00
#UB 0 2210 -700.00
#IB 0 2250 1000.00
#UB 0 2250 1500.00
#IB 0 2300 -2600.00
#UB 0 2300 -3100.00
#IB 0 2310 -6500.00
#UB 0 2310 -7000.00
#IB 0 2320 -2600.00
#UB 0 2320 -3200.00
#IB 0 2331 -2700.00
#UB 0 2331 -3500.00
#IB 0 2340 -15000.00
#UB 0 2340 -14800.00
#IB 0 2350 -12000.00
#UB 0 2350 -13200.00
#IB 0 2360 19400.00
#UB 0 2360 18550.00
#IB 0 2370 -2300.00
#UB 0 2370 -3500.00
#IB 0 2410 -4700.00
#UB 0 2410 -5700.00
#IB 0 2411 -3150.00
#UB 0 2411 -3650.00
#IB 0 2412 -9220.00
#UB 0 2412 -10220.00
#IB 0 2420 -5940.00
#UB 0 2420 -6150.00
#IB 0 2421 -2642.00
#UB 0 2421 -3042.00
#IB 0 2422 -5410.00
#UB 0 2422 -6210.00
#IB 0 2450 -4110.00
#UB 0 2450 -4610.00
#IB 0 2480 -3310.00
#UB 0 2480 -7300.00
#IB 0 2510 -5196.00
#UB 0 2510 -7696.00
#IB 0 2520 -200.00
#UB 0 2520 -700.00
#IB 0 2530 -521.00
#UB 0 2530 -2321.00
#IB 0 2550 1344.00
#UB 0 2550 744.00
#IB 0 2560 850.00
#UB 0 2560 650.00
#IB 0 2590 -480.00
#UB 0 2590 -980.00
#IB 0 2610 6942.00
#UB 0 2610 -858.00
#IB 0 2640 -4800.00
#UB 0 2640 -5400.00
#IB 0 2690 1500.00
#UB 0 2690 500.00
#IB 0 2710 -4000.00
#UB 0 2710 -8950.00
#IB 0 2720 -6000.00
#UB 0 2720 -8250.00
#IB 0 2740 -2000.00
#UB 0 2740 -500.00
#IB 0 2750 1610.00
#UB 0 2750 4110.00
#IB 0 2794 -4350.00
#UB 0 2794 -10350.00
#IB 0 2799 200.00
#UB 0 2799 1900.00
#IB 0 2813 -6500.00
#UB 0 2813 -4700.00
#IB 0 2820 -5700.00
#UB 0 2820 -5700.00
#IB 0 2860 -8500.00
#UB 0 2860 -7300.00
#IB 0 2871 -500.00
#UB 0 2871 -350.00
#IB 0 2872 -800.00
#UB 0 2872 -3650.00
#IB 0 2873 -200.00
#UB 0 2873 -700.00
#IB 0 2891 100.00
#UB 0 2891 -150.00
#IB 0 2991 -500.00
#UB 0 2991 -6300.00
#IB 0 2992 -4400.00
#UB 0 2992 -4200.00
#IB 0 2997 -400.00
#UB 0 2997 -900.00
#IB 0 2998 150.00
#UB 0 2998 -4850.00
#IB 0 2999 -600.00
#UB 0 2999 11250.00
#DIM 1 Kostnadsst�lle
#OBJEKT 1 1 Service
#OBJEKT 1 2 Ekonomi
#OBJEKT 1 3 Distribution
#VER """" 1 ", year, @"0101 ""Verifikationstext ", year, @"""
{
   #TRANS 1010 {} 2500.00
   #TRANS 1020 {} -2500.00
}
#VER """" 2 ", year, @"0104 ""Verifikationstext ", year, @"""
{
   #TRANS 1040 {} 200.00
   #TRANS 1050 {} -200.00
}
#VER """" 3 ", year, @"0108 ""Verifikationstext ", year, @"""
{
   #TRANS 1120 {1 1} 5000.00
   #TRANS 1130 {} -5000.00
}
#VER """" 4 ", year, @"0113 ""Verifikationstext ", year, @"""
{
   #TRANS 1210 {} 50000.00 ", year, @"0113 """" 5000
   #TRANS 1220 {} -50000.00
}
#VER """" 5 ", year, @"0127 ""Verifikationstext ", year, @"""
{
   #TRANS 1230 {} 8000.00
   #TRANS 1290 {} -8000.00
}
#VER """" 6 ", year, @"0130 ""Verifikationstext ", year, @"""
{
   #TRANS 1310 {} 8500.00
   #TRANS 1340 {} -8500.00
}
#VER """" 7 ", year, @"0202 ""Verifikationstext ", year, @"""
{
   #TRANS 1350 {} 5000.00
   #TRANS 1360 {} -5000.00
}
#VER """" 8 ", year, @"0205 ""Verifikationstext ", year, @"""
{
   #TRANS 1360 {} -8500.00
   #TRANS 1390 {} 8500.00
}
#VER """" 9 ", year, @"0216 ""Verifikationstext ", year, @"""
{
   #TRANS 1390 {} 500.00
   #TRANS 1410 {} -500.00
}
#VER """" 10 ", year, @"0223 ""Verifikationstext ", year, @"""
{
   #TRANS 1411 {} 8500.00 ", year, @"0223 """" 500
   #TRANS 1412 {} -8500.00
}
#VER """" 11 ", year, @"0224 ""Verifikationstext ", year, @"""
{
   #TRANS 1450 {} 5000.00
   #TRANS 1470 {1 3} -5000.00
}
#VER """" 12 ", year, @"0226 ""Verifikationstext ", year, @"""
{
   #TRANS 1480 {} 8500.00
   #TRANS 1490 {} -8500.00 ", year, @"0226 """" 200
}
#VER """" 13 ", year, @"0228 ""Verifikationstext ", year, @"""
{
   #TRANS 1510 {} 8500.00
   #TRANS 1530 {1 3} -8500.00 ", year, @"0228 """" 500
}
#VER """" 14 ", year, @"0301 ""Verifikationstext ", year, @"""
{
   #TRANS 1550 {} 300.00
   #TRANS 1530 {1 2} -300.00 ", year, @"0301 """" 500
}
#VER """" 15 ", year, @"0303 ""Verifikationstext ", year, @"""
{
   #TRANS 1551 {} 500.00
   #TRANS 1580 {} -500.00
}
#VER """" 16 ", year, @"0308 ""Verifikationstext ", year, @"""
{
   #TRANS 1611 {1 3} 1500.00
   #TRANS 1621 {} -1500.00
}
#VER """" 17 ", year, @"0312 ""Verifikationstext ", year, @"""
{
   #TRANS 1621 {} 500.00
   #TRANS 1622 {} -500.00
}
#VER """" 18 ", year, @"0315 ""Verifikationstext ", year, @"""
{
   #TRANS 1625 {1 3} 1500.00 ", year, @"0315 """" 500
   #TRANS 1626 {} -1500.00
}
#VER """" 19 ", year, @"0317 ""Verifikationstext ", year, @"""
{
   #TRANS 1630 {} 200.00 ", year, @"0317 """" 800
   #TRANS 1650 {1 1} -200.00
}
#VER """" 20 ", year, @"0320 ""Verifikationstext ", year, @"""
{
   #TRANS 1690 {} -120.00
   #TRANS 1710 {1 2} 1500.00
   #TRANS 1720 {} 200.00
   #TRANS 1730 {} 200.00
   #TRANS 1740 {} -500.00
   #TRANS 1810 {} -1280.00 ", year, @"0320 """" 200
}
#VER """" 21 ", year, @"0402 ""Verifikationstext ", year, @"""
{
   #TRANS 1819 {} 5000.00
   #TRANS 1820 {} 200.00
   #TRANS 1830 {} 3200.00
   #TRANS 1829 {1 2} 2500.00 ", year, @"0402 """" 1500
   #TRANS 1840 {1 2} -10900.00
}
#VER """" 22 ", year, @"0402 ""Verifikationstext ", year, @"""
{
   #TRANS 1849 {} -500.00
   #TRANS 1880 {1 1} 500.00
}
#VER """" 23 ", year, @"0410 ""Verifikationstext ", year, @"""
{
   #TRANS 1919 {} 1200.00 ", year, @"0410 """" 500
   #TRANS 1940 {} -1200.00
}
#VER """" 24 ", year, @"0415 ""Verifikationstext ", year, @"""
{
   #TRANS 1919 {} 1500.00 ", year, @"0415 """" 500
   #TRANS 1940 {} -1500.00
}
#VER """" 25 ", year, @"0420 ""Verifikationstext ", year, @"""
{
   #TRANS 1950 {1 1} 500.00
   #TRANS 1980 {} -500.00
}
#VER """" 26 ", year, @"0423 ""Verifikationstext ", year, @"""
{
   #TRANS 2010 {1 3} -5000.00 ", year, @"0423 """" 500
   #TRANS 2110 {} -8500.00
   #TRANS 1020 {} 13500.00
}
#VER """" 27 ", year, @"0427 ""Verifikationstext ", year, @"""
{
   #TRANS 2250 {} 500.00
   #TRANS 2300 {} -500.00
}
#VER """" 28 ", year, @"0429 ""Verifikationstext ", year, @"""
{
   #TRANS 2310 {} -500.00 ", year, @"0429 """" 500
   #TRANS 1020 {} 500.00
}
#VER """" 29 ", year, @"0501 ""Verifikationstext ", year, @"""
{
   #TRANS 2331 {} -500.00
   #TRANS 2340 {} -200.00
   #TRANS 2350 {1 2} -200.00 ", year, @"0501 """" 200
   #TRANS 2360 {} -500.00
   #TRANS 2370 {} -500.00
   #TRANS 2410 {} -800.00
   #TRANS 1020 {} 2700.00
}
#VER """" 30 ", year, @"0505 ""Verifikationstext ", year, @"""
{
   #TRANS 2412 {} -500.00
   #TRANS 2420 {} -200.00
   #TRANS 2421 {} -200.00
   #TRANS 2422 {} -500.00
   #TRANS 2450 {1 2} -500.00
   #TRANS 2480 {} -5700.00
   #TRANS 1210 {} 7600.00 ", year, @"0505 """" 500
}
#VER """" 31 ", year, @"0511 ""Verifikationstext ", year, @"""
{
   #TRANS 2520 {1 1} -500.00
   #TRANS 2530 {} -800.00
   #TRANS 2550 {} -800.00
   #TRANS 2560 {} -500.00 ", year, @"0511 """" 500
   #TRANS 2590 {} -800.00
   #TRANS 1040 {} 3400.00
}
#VER """" 32 ", year, @"0523 ""Verifikationstext ", year, @"""
{
   #TRANS 2590 {} -200.00
   #TRANS 2610 {1 2} -8000.00 ", year, @"0523 """" 500
   #TRANS 2640 {} -800.00
   #TRANS 2690 {} -100.00
   #TRANS 2710 {1 1} -200.00 ", year, @"0523 """" 570
   #TRANS 4010 {1 1} 9300.00
}
#VER """" 33 ", year, @"0527 ""Verifikationstext ", year, @"""
{
   #TRANS 2710 {1 1} -5000.00 ", year, @"0527 """" 2000
   #TRANS 2720 {} -2000.00
   #TRANS 4081 {} 7000.00
}
#VER """" 34 ", year, @"0530 ""Verifikationstext ", year, @"""
{
   #TRANS 2320 {} -800.00
   #TRANS 2331 {} -500.00
   #TRANS 2340 {} -100.00
   #TRANS 2350 {1 1} -500.00 ", year, @"0530 """" 500
   #TRANS 4610 {1 2} 1900.00
}
#VER """" 35 ", year, @"0601 ""Verifikationstext ", year, @"""
{
   #TRANS 2370 {} -200.00
   #TRANS 2410 {} -200.00
   #TRANS 3011 {1 2} -2000.00 ", year, @"0601 """" 250
   #TRANS 1020 {} 2400.00
}
#VER """" 36 ", year, @"0609 ""Verifikationstext ", year, @"""
{
   #TRANS 2411 {1 2} -500.00 ", year, @"0609 """" 200
   #TRANS 2412 {} -500.00
   #TRANS 2420 {} -10.00
   #TRANS 2421 {} -200.00
   #TRANS 2422 {} -500.00
   #TRANS 2480 {} 1710.00
}
#VER """" 37 ", year, @"0612 ""Verifikationstext ", year, @"""
{
   #TRANS 2320 {} 200.00
   #TRANS 2331 {} 200.00
   #TRANS 2340 {} 500.00
   #TRANS 2350 {1 1} -500.00
   #TRANS 2360 {} -350.00
   #TRANS 2370 {} -500.00
   #TRANS 2422 {} 200.00
   #TRANS 2510 {} -2500.00
   #TRANS 2530 {} -500.00
   #TRANS 1020 {} 3250.00
}
#VER """" 38 ", year, @"0622 ""Verifikationstext ", year, @"""
{
   #TRANS 2530 {} -500.00
   #TRANS 2550 {} 200.00
   #TRANS 2560 {} 300.00 ", year, @"0622 """" 200
}
#VER """" 39 ", year, @"0625 ""Verifikationstext ", year, @"""
{
   #TRANS 2590 {} 500.00
   #TRANS 2610 {1 2} 200.00 ", year, @"0625 """" 500
   #TRANS 2640 {} 200.00
   #TRANS 2690 {} -900.00
}
#VER """" 40 ", year, @"0626 ""Verifikationstext ", year, @"""
{
   #TRANS 2710 {1 1} 250.00 ", year, @"0626 """" 150
   #TRANS 2720 {} -250.00
}
#VER """" 41 ", year, @"0628 ""Verifikationstext ", year, @"""
{
   #TRANS 2740 {} 1500.00
   #TRANS 2750 {} 2500.00
   #TRANS 2794 {1 2} -4000.00 ", year, @"0628 """" 1500
}
#VER """" 42 ", year, @"0628 ""Verifikationstext ", year, @"""
{
   #TRANS 2794 {1 1} -2000.00 ", year, @"0628 """" 1500
   #TRANS 2799 {} 200.00
   #TRANS 2813 {1 2} 1800.00 ", year, @"0628 """" 200
}
#VER """" 43 ", year, @"0629 ""Verifikationstext ", year, @"2799""
{
   #TRANS 2799 {} 1500.00
   #TRANS 2860 {1 2} 1200.00 ", year, @"0629 """" 1500
   #TRANS 2871 {1 3} 150.00
   #TRANS 2872 {} -2850.00
}
#VER """" 44 ", year, @"0701 ""Verifikationstext ", year, @"""
{
   #TRANS 2873 {} -500.00
   #TRANS 2891 {} -250.00
   #TRANS 2991 {} -5800.00 ", year, @"0701 """" 500
   #TRANS 2992 {} 200.00
   #TRANS 2997 {} -500.00
   #TRANS 2998 {} -5000.00
   #TRANS 2999 {1 3} 11850.00
}
#VER """" 45 ", year, @"0704 ""Verifikationstext ", year, @"""
{
   #TRANS 3011 {1 1} -15000.00 ", year, @"0704 """" 1000
   #TRANS 3012 {} -6000.00 ", year, @"0704 """" 1200
   #TRANS 3013 {1 1} -8000.00
   #TRANS 3014 {} -500.00
   #TRANS 3015 {} -8000.00 ", year, @"0704 """" 5800
   #TRANS 1210 {} 37500.00 ", year, @"0704 """" 15000
}
#VER """" 46 ", year, @"0711 ""Verifikationstext ", year, @"""
{
   #TRANS 3081 {} 1500.00
   #TRANS 3510 {} -1500.00
}
#VER """" 47 ", year, @"0713 ""Verifikationstext ", year, @"""
{
   #TRANS 3631 {1 2} -8000.00
   #TRANS 3632 {} 1500.00
   #TRANS 3650 {1 1} 6500.00 ", year, @"0713 """" 1500
}
#VER """" 48 ", year, @"0715 ""Verifikationstext ", year, @"""
{
   #TRANS 3690 {} -500.00
   #TRANS 3720 {1 1} 2500.00
   #TRANS 3770 {} -2000.00
}
#VER """" 49 ", year, @"0717 ""Verifikationstext ", year, @"""
{
   #TRANS 3780 {} 1500.00
   #TRANS 3810 {} -1500.00
}
#VER """" 50 ", year, @"0720 ""Verifikationstext ", year, @"""
{
   #TRANS 3880 {1 1} -500.00 ", year, @"0720 """" 1500
   #TRANS 3890 {} 1500.00
   #TRANS 3910 {} -1000.00 ", year, @"0720 """" 500
}
#VER """" 51 ", year, @"0722 ""Verifikationstext ", year, @"""
{
   #TRANS 3990 {} -500.00
   #TRANS 4010 {1 2} 500.00
}
#VER """" 52 ", year, @"0725 ""Verifikationstext ", year, @"""
{
   #TRANS 4010 {1 3} 5000.00
   #TRANS 4081 {} 2500.00
   #TRANS 4090 {} 5000.00
   #TRANS 1020 {} -12500.00
}
#VER """" 53 ", year, @"0729 ""Verifikationstext ", year, @"""
{
   #TRANS 4610 {1 2} -8000.00
   #TRANS 4910 {} 8000.00
   #TRANS 1910 {} 1500.00
   #TRANS 4910 {} -8800.00
   #TRANS 1020 {} 7300.00
}
#VER """" 54 ", year, @"0731 ""Verifikationstext ", year, @"""
{
   #TRANS 5010 {1 2} 15000.00 ", year, @"0731 """" 5000
   #TRANS 1020 {} -15000.00
}
#VER """" 55 ", year, @"0801 ""Verifikationstext ", year, @"""
{
   #TRANS 5082 {} 52200.00
   #TRANS 5090 {} 2000.00
   #TRANS 5210 {1 2} -54200.00
}
#VER """" 56 ", year, @"0803 ""Verifikationstext ", year, @"""
{
   #TRANS 5210 {1 1} -80000.00
   #TRANS 1040 {} 80000.00
}
#VER """" 57 ", year, @"0806 ""Verifikationstext ", year, @"""
{
   #TRANS 8090 {1 1} -5000.00
   #TRANS 5090 {} 5000.00
}
#VER """" 58 ", year, @"0809 ""Verifikationstext ", year, @"""
{
   #TRANS 5210 {1 1} 1500.00
   #TRANS 5220 {} 1500.00
   #TRANS 5300 {1 3} 5000.00 ", year, @"0809 """" 5000
   #TRANS 5400 {} -8000.00
}
#VER """" 59 ", year, @"0813 ""Verifikationstext ", year, @"""
{
   #TRANS 5410 {} 1500.00
   #TRANS 5420 {} -1500.00 ", year, @"0813 """" 520
}
#VER """" 60 ", year, @"0817 ""Verifikationstext ", year, @"""
{
   #TRANS 5400 {} 8000.00
   #TRANS 5410 {} 1500.00
   #TRANS 5420 {} 200.00 ", year, @"0817 """" 540
   #TRANS 5450 {} 2500.00
   #TRANS 1020 {} -12200.00
}
#VER """" 61 ", year, @"0823 ""Verifikationstext ", year, @"""
{
   #TRANS 5521 {} 1500.00
   #TRANS 5522 {} 2500.00
   #TRANS 5523 {} 500.00
   #TRANS 5524 {} 500.00
   #TRANS 5531 {} 1560.00
   #TRANS 5590 {1 2} -6560.00 ", year, @"0823 """" 552
}
#VER """" 62 ", year, @"0823 ""Verifikationstext ", year, @"""
{
   #TRANS 5631 {} 5000.00
   #TRANS 5670 {} 500.00
   #TRANS 5710 {} 5500.00
   #TRANS 5711 {} 1150.00
   #TRANS 5712 {} -12150.00 ", year, @"0823 """" 200
}
#VER """" 63 ", year, @"0829 ""Verifikationstext ", year, @"""
{
   #TRANS 5670 {} 1500.00
   #TRANS 5710 {} 1500.00
   #TRANS 5711 {} 200.00
   #TRANS 5712 {} 2550.00 ", year, @"0829 """" 200
   #TRANS 5790 {} -5750.00
}
#VER """" 64 ", year, @"0830 ""Verifikationstext ", year, @"""
{
   #TRANS 5790 {} 200.00
   #TRANS 5800 {} -200.00
}
#VER """" 65 ", year, @"0831 ""Verifikationstext ", year, @"""
{
   #TRANS 5890 {} 500.00
   #TRANS 6010 {} -500.00 ", year, @"0831 """" 200
}
#VER """" 66 ", year, @"0901 ""Verifikationstext ", year, @"""
{
   #TRANS 6050 {} 500.00
   #TRANS 6060 {} 2500.00
   #TRANS 6070 {} 200.00
   #TRANS 6080 {} 3500.00
   #TRANS 6090 {} -6700.00
}
#VER """" 67 ", year, @"0905 ""Verifikationstext ", year, @"""
{
   #TRANS 6110 {} 1500.00
   #TRANS 6120 {} -1500.00
}
#VER """" 68 ", year, @"0909 ""Verifikationstext ", year, @"""
{
   #TRANS 6280 {} 1500.00
   #TRANS 6290 {} -1500.00
}
#VER """" 69 ", year, @"0912 ""Verifikationstext ", year, @"""
{
   #TRANS 6410 {} 1500.00
   #TRANS 6460 {} 500.00
   #TRANS 6510 {} 200.00
   #TRANS 6550 {} 200.00
   #TRANS 6600 {1 1} -2400.00 ", year, @"0912 """" 1200
}
#VER """" 70 ", year, @"0916 ""Verifikationstext ", year, @"""
{
   #TRANS 6730 {1 2} 500.00
   #TRANS 6740 {} 200.00
   #TRANS 6750 {} 200.00
   #TRANS 6780 {} -900.00
}
#VER """" 71 ", year, @"0920 ""Verifikationstext ", year, @"""
{
   #TRANS 6780 {} 2500.00
   #TRANS 6790 {} 200.00
   #TRANS 6810 {} -2700.00
}
#VER """" 72 ", year, @"0924 ""Verifikationstext ", year, @"""
{
   #TRANS 6911 {} 2000.00
   #TRANS 6912 {} 200.00
   #TRANS 6913 {} 5000.00
   #TRANS 6915 {} -7200.00
}
#VER """" 73 ", year, @"0928 ""Verifikationstext ", year, @"""
{
   #TRANS 6915 {} 200.00
   #TRANS 6990 {} -200.00
}
#VER """" 74 ", year, @"0930 ""Verifikationstext ", year, @"""
{
   #TRANS 7010 {1 3} 500.00
   #TRANS 7020 {} -500.00
}
#VER """" 75 ", year, @"1001 ""Verifikationstext ", year, @"""
{
   #TRANS 7020 {} 500.00
   #TRANS 7050 {} -500.00
}
#VER """" 76 ", year, @"1005 ""Verifikationstext ", year, @"""
{
   #TRANS 7050 {} 250.00
   #TRANS 7090 {} -250.00
}
#VER """" 77 ", year, @"1009 ""Verifikationstext ", year, @"""
{
   #TRANS 7110 {} 350.00
   #TRANS 7150 {} 800.00
   #TRANS 7160 {} -1150.00
}
#VER """" 78 ", year, @"1016 ""Verifikationstext ", year, @"""
{
   #TRANS 7160 {} 500.00
   #TRANS 7171 {} 5000.00
   #TRANS 7172 {} 500.00
   #TRANS 7173 {} 800.00
   #TRANS 7190 {} -500.00
   #TRANS 7200 {} -6300.00
}
#VER """" 79 ", year, @"1018 ""Verifikationstext ", year, @"""
{
   #TRANS 7200 {} 1500.00
   #TRANS 7240 {} 2500.00
   #TRANS 7310 {} 500.00
   #TRANS 7350 {} 500.00
   #TRANS 7390 {} 8500.00
   #TRANS 7410 {} 500.00
   #TRANS 7420 {1 1} -8000.00 ", year, @"1018 """" 800
   #TRANS 7490 {} -6000.00
}
#VER """" 80 ", year, @"1023 ""Verifikationstext ", year, @"""
{
   #TRANS 7670 {} 200.00
   #TRANS 7681 {} -200.00
}
#VER """" 81 ", year, @"1026 ""Verifikationstext ", year, @"""
{
   #TRANS 7682 {} 2500.00
   #TRANS 7681 {} -2500.00
}
#VER """" 82 ", year, @"1029 ""Verifikationstext ", year, @"""
{
   #TRANS 7691 {} 5800.00 ", year, @"1029 """" 500
   #TRANS 7692 {} 1500.00
   #TRANS 7693 {} 4500.00
   #TRANS 7695 {} -11800.00
}
#VER """" 83 ", year, @"1031 ""Verifikationstext ", year, @"""
{
   #TRANS 7710 {} 1500.00
   #TRANS 7720 {} 2500.00
   #TRANS 7730 {} 500.00
   #TRANS 7740 {} 500.00
   #TRANS 7750 {} -5000.00
}
#VER """" 84 ", year, @"1101 ""Verifikationstext ", year, @"""
{
   #TRANS 7750 {} 500.00
   #TRANS 7760 {} -500.00
}
#VER """" 85 ", year, @"1104 ""Verifikationstext ", year, @"""
{
   #TRANS 7770 {} 500.00
   #TRANS 7791 {} -500.00
}
#VER """" 86 ", year, @"1106 ""Verifikationstext ", year, @"""
{
   #TRANS 7710 {} 1500.00
   #TRANS 1020 {} -1500.00
}
#VER """" 87 ", year, @"1106 ""Verifikationstext ", year, @"""
{
   #TRANS 7720 {} -500.00
   #TRANS 7730 {} -500.00
   #TRANS 7740 {} -200.00
   #TRANS 7750 {} 500.00
   #TRANS 7760 {} 200.00
   #TRANS 7770 {} 500.00
}
#VER """" 88 ", year, @"1113 ""Verifikationstext ", year, @"""
{
   #TRANS 7791 {} 500.00
   #TRANS 7799 {} -200.00
   #TRANS 7810 {} -200.00
   #TRANS 7820 {} -200.00
   #TRANS 7861 {} -500.00
   #TRANS 7891 {} -200.00
   #TRANS 7892 {} 800.00
}
#VER """" 89 ", year, @"1120 ""Verifikationstext ", year, @"""
{
   #TRANS 7912 {1 1} 500.00
   #TRANS 7913 {} 200.00
   #TRANS 7914 {} 500.00
   #TRANS 7921 {} 200.00
   #TRANS 7928 {} 200.00
   #TRANS 7933 {} -500.00 ", year, @"1120 """" 500
   #TRANS 8011 {} 500.00
   #TRANS 8012 {} 500.00
   #TRANS 8015 {} -500.00
   #TRANS 8016 {} -500.00
   #TRANS 8020 {} -800.00
   #TRANS 8050 {1 3} 4500.00 ", year, @"1120 """" 4500
   #TRANS 8080 {} -4800.00
}
#VER """" 90 ", year, @"1124 ""Verifikationstext ", year, @"""
{
   #TRANS 8090 {1 2} 500.00
   #TRANS 8120 {} 500.00 ", year, @"1124 """" 500
   #TRANS 8150 {} -1000.00
}
#VER """" 91 ", year, @"1125 ""Verifikationstext ", year, @"""
{
   #TRANS 8150 {} -500.00
   #TRANS 8170 {} 500.00
   #TRANS 8180 {} -300.00
   #TRANS 8190 {} 300.00
}
#VER """" 92 ", year, @"1125 ""Verifikationstext ", year, @"""
{
   #TRANS 8310 {1 3} -500.00
   #TRANS 8320 {} 1500.00
   #TRANS 8390 {} 2000.00
   #TRANS 8410 {1 2} 8000.00 ", year, @"1125 """" 500
   #TRANS 8490 {} -11000.00
}
#VER """" 93 ", year, @"1201 ""Verifikationstext ", year, @"""
{
   #TRANS 8490 {} 500.00
   #TRANS 8814 {1 2} -500.00 ", year, @"1201 """" 790
}
#VER """" 94 ", year, @"1206 ""Verifikationstext ", year, @"""
{
   #TRANS 8820 {} 500.00
   #TRANS 8860 {1 3} -500.00 ", year, @"1206 """" 450
}
#VER """" 95 ", year, @"1211 ""Verifikationstext ", year, @"""
{
   #TRANS 8872 {} 500.00
   #TRANS 8873 {} -500.00
}
#VER """" 96 ", year, @"1221 ""Verifikationstext ", year, @"""
{
   #TRANS 8873 {} 500.00
   #TRANS 8874 {} 500.00 ", year, @"1221 """" 800
   #TRANS 8910 {1 3} -1000.00
}
#VER """" 97 ", year, @"1228 ""Verifikationstext ", year, @"""
{
   #TRANS 8940 {} 500.00
   #TRANS 8999 {1 2} -8500.00
   #TRANS 9999 {} 8000.00
}
#VER """" 98 ", year, @"1228 """"
{
   #TRANS 3011 {1 3} -75000.00 ", year, @"1228 """" 500
   #TRANS 1020 {} 75000.00
}
#VER """" 99 ", year, @"1228 ""Verifikationstext ", year, @"""
{
   #TRANS 3011 {1 3} 5000.00 ", year, @"1228 """" 500
   #TRANS 1020 {} -5000.00
}
#VER """" 100 ", year, @"1228 ""Verifikationstext ", year, @"""
{
   #TRANS 3011 {1 3} 60000.00 ", year, @"1228 """" 500
   #TRANS 1020 {} -60000.00
}
#VER """" 101 ", year, @"1228 """"
{
   #TRANS 5010 {1 1} 3000.00 ", year, @"1228 """" 500
   #TRANS 1020 {} -3000.00
}
#KSUMMA 1625629201
");
		}
	}
}
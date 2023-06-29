class funkcje:
    @staticmethod
    def wnioskowanie(typ, klient):
        wyniki = []
        
        for i in range(len(typ)):
            wyniki.append(0.0)
            if klient[4] in typ[i].Plec or "neutralne" in typ[i].Plec:
                if klient[0] in typ[i].Pora_roku:
                    wyniki[i] += (float(klient[1]))
                if klient[2] in typ[i].Pogoda:
                    wyniki[i] += (float(klient[3]))
                wyniki[i] *= (float(typ[i].Waga))
        
        maks = max(wyniki)
        indeksy = []
        for j in range(len(wyniki)):
            if wyniki[j] == maks:
                indeksy.append(j + 1)
        
        while True:
            if len(indeksy) >= 4:
                break
            
            for j in range(len(wyniki)):
                if wyniki[j] == maks:
                    wyniki[j] = 0
            
            maks = max(wyniki)
            
            for j in range(len(wyniki)):
                if wyniki[j] == maks:
                    indeksy.append(j + 1)
        
        return indeksy


butyLista = funkcje.wnioskowanie(Buty, Klient)
bluzkaLista = funkcje.wnioskowanie(Bluzka, Klient)
dodatkiLista = funkcje.wnioskowanie(Dodatki, Klient)
nakrycieLIsta = funkcje.wnioskowanie(Nakrycie, Klient)
spodnieLista = funkcje.wnioskowanie(Spodnie, Klient)

sciezka = "H:\\SSSSSSSSSSSSSSSSSSS\\wyniki.txt";

z1 = list(map(str, butyLista))
z2 = list(map(str, bluzkaLista))
z3 = list(map(str, dodatkiLista))
z4 = list(map(str, nakrycieLIsta))
z5 = list(map(str, spodnieLista))

with open(sciezka, "w") as plik:
    line = [z1, z2, z3, z4, z5]
    plik.writelines(" ".join(line) + "\n" for line in line)
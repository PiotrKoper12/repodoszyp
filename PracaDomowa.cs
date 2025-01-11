void BubbleSort(int[] tab)
{
    for(int i =0; i< tab.Length-1; i++)
    {
        for(int j=0;j<tab.Length-1-i;j++)
        {
            if (tab[j]>tab[j+1])
            {
                int pom = tab[j];
                tab[j]=tab[j+1];
                tab[j+1]=pom;
            }
            
        }
    }

}

void InsertionSort(int[] tab)
{
    for(int i = 1; i< tab.Length; i++)
    {
        int j = i - 1;
        int klucz = tab[i];

        while(j>=0&&tab[j]>klucz)
        {
            tab[j+1] = tab[j];
            j--;
        }
        tab[j+1] = klucz;

    }
}

void MergeSort(int[] tab)
{
    if (tab.Length<=1)
    {
        return;
    }    
    int srodek = tab.Length/2;
    int[] lewatablica = new int[srodek];
    int[] prawatablica = new int[tab.Length-srodek];

    for(int i = 0; i<srodek; i++)
    {
        lewatablica[i] = tab[i];
    }
    for(int i = srodek;i<tab.Length; i++)
    {
        prawatablica[i-srodek] = tab[i];
    }   
    MergeSort(lewatablica);
    MergeSort(prawatablica);
    Merge(tab,lewatablica,prawatablica);
}

void Merge(int[] tab, int[] lewatablica, int[] prawatablica)
{
    int indekslewy = 0;
    int indeksprawy = 0;
    int indeksglowny = 0;

    while(indekslewy<lewatablica.Length&&indeksprawy<prawatablica.Length)
    {
        if (lewatablica[indekslewy]<prawatablica[indeksprawy])
        {
            tab[indeksglowny++] = lewatablica[indekslewy++];
        }
        else
        {
            tab[indeksglowny++]=prawatablica[indeksprawy++];
        }
    }
    while(indekslewy<lewatablica.Length)
    {
        tab[indeksglowny++] = lewatablica[indekslewy++];
    }
    while (indeksprawy<prawatablica.Length)
    {
        tab[indeksglowny++]=prawatablica[indeksprawy++];
    }
}

void CountingSort(int[] tab)
{
    int Mx = tab.Max();
    int Mn = tab.Min();
    int[] nowatablica = new int[Mx-Mn+1];

    for (int i = 0; i < tab.Length; i++)
    {
        nowatablica[tab[i]-Mn]++;
        
    }



    int x = 0;
    for(int i = 0;i < nowatablica.Length;i++)
    {
        while(nowatablica[i] > 0)
        {
            tab[x] = i+Mn;
            x++; 
            nowatablica[i]--;
        }
    }

}


void QuickSort(int[] array, int dolny, int gorna)
{
    if (dolny < gorna)
    {
        int pivotIndex = podzieltab(array, dolny, gorna);
        QuickSort(array, dolny, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, gorna);
    }
}

int podzieltab(int[] array, int dolny1, int gorny2)
{
    int pivot = array[gorny2];
    int i = dolny1 - 1;

    for (int j = dolny1; j < gorny2; j++)
    {
        if (array[j] <= pivot)
        {
            i++;
            Zamien(array, i, j);
        }
    }
    Zamien(array, i + 1, gorny2);
    return i + 1;
}
void Zamien(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}


void Wyswietltab(int[] tab)
{
    Console.WriteLine();
    for (int i =0; i < tab.Length; i++)
    {
        Console.WriteLine(tab[i]);
    }    
}


int[] tablica = { 4, 4, 2, 2, 5, 7, 3, 10, 13, 12, 5, 12, 6 };

Wyswietltab(tablica);
QuickSort(tablica,0,tablica.Length-1);
Wyswietltab(tablica);

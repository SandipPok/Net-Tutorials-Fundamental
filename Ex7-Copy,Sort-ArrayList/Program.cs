using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        ArrayList arrayList = new ArrayList()
        {
            "India",
            "USA",
            "UK",
            "Denmark",
            "Nepal",
            "HongKong",
            "Australia",
            "Indonasia",
            "Japan",
            "South Korea",
            "Brazil",
        };

        object[] arr = new object[arrayList.Count + 3];

        SortArrayList(arrayList);

        CopyToArrayList(arrayList, arr);

        Console.WriteLine("\nArrayList Copy Array Elements:");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }

    public static void CopyToArrayList(ArrayList arrayList, object[] arr)
    {
        //arrayList.CopyTo(arr);
        //arrayList.CopyTo(arr, 2);

        // params:
        // from index of arraylist, copy to 1D array,
        // Copy from 1D array, number of element of arraylist
        arrayList.CopyTo(2, arr, 2, 6);
    }

    public static void SortArrayList(ArrayList arrayList)
    {
        arrayList.Sort();
    }
}
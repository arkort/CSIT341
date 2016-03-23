package hj;
import java.util.Random;
/**
 * Created by AkimovAA on 02.03.2016.
 */
public class hgj {
    public  static  void main(String[] args)
    {
        Random random = new Random(5);



        int n= 100;
        int[] mas2 =  new int[n];
        for(int i=0; i<n; i++)
        {
            mas2[i] = random.nextInt(100)-50    ;
        }
      bubbleSort(mas2);

    }

        public static void bubbleSort(int[] arr) {
            System.out.println("Before:");


            for(int i = 0; i < arr.length  ; i++)
            {
                System.out.print(arr[i] + "  ");
            }

        for (int i = 0; i < arr.length; i++)
        {
            for (int j = 0; j < arr.length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int t = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = t;
                }
            }
        }
            System.out.println();
            System.out.println("After:");
            for(int i = 0; i < arr.length  ; i++)
            {
                System.out.print(arr[i] + "  ");
    }

    }
}

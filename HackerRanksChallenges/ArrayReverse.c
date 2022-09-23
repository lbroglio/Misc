#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num, *arr, i;
    scanf("%d", &num);
    arr = (int*) malloc(num * sizeof(int));
    for(i = 0; i < num; i++) {
        scanf("%d", arr + i);
    }

    int* revArr;
    revArr = (int*) malloc(num * sizeof(int));
    for(i =0; i < num; i++){
        *(revArr + i) = *((arr + num -1) -i);
    }
    free(arr);
    arr = revArr;

    for(i = 0; i < num; i++)
        printf("%d ", *(arr + i));
    return 0;
}
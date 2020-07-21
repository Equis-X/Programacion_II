#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>
//
//
int Climate(char data[]){
    char *token = strtok(data, ",");
    token = strtok(NULL, ",");
    char *num1= token;
    token = strtok(NULL, ",");
    char *num2= token;
    token = strtok(NULL, ",");
    char *num3= token;
    //
    int no1, no2, no3;
    no1 = atoi(num1);
    no2 = atoi(num2);
    no3 = atoi(num3);
    //
    no1 = no1<<14;
    no2 = no2<<7;
    no3 = no3|no2|no1;
    //
    return no3;
}
//
long long DateAndTime(char data[]){
    char *raw;
    int num1, num2, num3, num4, num5, num6, num7, num8, num9;
    long long res, temp1, temp2;
    bool minus = false;
    //
    sscanf(data,"%s,leave,leave,leave",raw);
    //
    if (raw[23]=='+')
    {
        sscanf(raw,"%d-%d-%dT%d:%d:%d.%d+%d:%d",
        &num1,&num2,&num3,&num4,&num5,&num6,&num7,&num8,&num9);
    }
    else
    {
        sscanf(raw,"%d-%d-%dT%d:%d:%d.%d-%d:%d",
        &num1,&num2,&num3,&num4,&num5,&num6,&num7,&num8,&num9);
        minus = true;
    }
    //
    temp1 = num1;
    temp1 = temp1<<47;
    temp2 = num2;
    temp2 = temp2<<43;
    res = temp1|temp2;
    //
    temp1 = num3;
    temp1 = temp1<<38;
    temp2 = num4;
    temp2 = temp2<<33;
    res = res|temp1|temp2;
    //
    temp1 = num5;
    temp1 = temp1<<27;
    temp2 = num6;
    temp2 = temp2<<21;
    res = res|temp1|temp2;
    //
    temp1 = num7;
    temp1 = temp1<<11;
    temp2 = num8;
    temp2 = temp2<<6;
    res = res|temp1|temp2;
    //
    temp1 = num9;
    res = res|temp1;
    //
    if (minus)
    {
        res = res * -1;
    }
    //
    return res;
}
//
void getter(){
    printf("Buscando documento...\n");
    char dir[] = "input.csv";
    char dirOUT[] = "output.csv";
    char lineas[60];
    int max;
    bool checker = true;
    if(access(dir,F_OK)!= -1){
        printf("DOCUMENTO ENCONTRADO!\n");
        if(access(dirOUT,F_OK)!= -1){
            checker = false;
        }
        else{
            checker = true;
        }
        FILE * fpointer = fopen(dir,"r");
            fseek(fpointer,0L,SEEK_END);
            max = ftell(fpointer);
            rewind(fpointer);
            //
            fgets(lineas, 60, fpointer);
            //
            printf("Codificando documento...\n");
            while (ftell(fpointer)!=max){
                fgets(lineas, 60, fpointer);
                FILE * fwritting = fopen(dirOUT,"a");
                    if (checker)
                    {
                        fprintf(fwritting,"DateAndTime,Climate\n");
                    }
                    fprintf(fwritting,"%ld,%d\n",DateAndTime(lineas),Climate(lineas));
                fclose(fwritting);   
            }
        fclose(fpointer);
        printf("CODIFICACION EXITOSA!\n");
    } else {
        printf("EL DOCUMENTO NO EXISTE!\n");
    }
}
//
int main(int argc, char const *argv[]){
    printf("CODIFICADOR DEL CLIMA\n");
    getter();
    return 0;
}
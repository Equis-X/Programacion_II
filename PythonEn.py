import sys
import os
import csv
# 
# 
def Climate(str,str1,str2):
    str = (int(str))<<14
    str1 = (int(str1))<<7
    str2 = int(str2)
    res = str|str1|str2
    return res
# 
def DateAndTime(str):
    minus = None
    if "+" in str:
        minus = False
        pass
    else:
        minus = True
        pass
    str = str.replace("-"," ")
    str = str.replace(":"," ")
    str = str.replace("."," ")
    str = str.replace("T"," ")
    str = str.replace("+"," ")
    rAw = str.split(" ")
    rAw[0] = (int(rAw[0]))<<47
    rAw[1] = (int(rAw[1]))<<43
    rAw[2] = (int(rAw[2]))<<38
    rAw[3] = (int(rAw[3]))<<33
    rAw[4] = (int(rAw[4]))<<27
    rAw[5] = (int(rAw[5]))<<21
    rAw[6] = (int(rAw[6]))<<11
    rAw[7] = (int(rAw[7]))<<6
    rAw[8] = (int(rAw[8]))
    res = rAw[0]|rAw[1]|rAw[2]|rAw[3]|rAw[4]|rAw[5]|rAw[6]|rAw[7]|rAw[8]
    if minus:
        res = res * -1
        pass
    return res
# 
def EXE(str):
        if os.path.exists(str):
            print("ARCHIVO ENCONTRADO!")
            with open(str) as csv_file:
                print("Leyendo archivo...")
                csv_reader = csv.reader(csv_file, delimiter=',')
                line_count = 0
                # 
                salida = 'output.csv'
                head = ['DateAndTime','Climate']
                # 
                header = None
                if os.path.exists(salida):
                    header = False
                    pass
                else:
                    header = True
                    pass
                # 
                for row in csv_reader:
                    if line_count == 0:
                        print('Transformando informacion...')
                        line_count += 1
                        pass
                    else:
                        rows = [DateAndTime(row[0]),Climate(row[1],row[2],row[3])]
                        with open(salida,"a+",newline='') as csv_file:
                            csvwriter = csv.writer(csv_file)
                            if header:
                                csvwriter.writerow(head)
                                header = False
                                pass
                            csvwriter.writerow(rows)
                            pass
                        pass
                    pass
                # 
                pass
            pass
# 
# 
print("CODIFICADOR DEL CLIMA")
print("Buscando archivo...")
EXE("input.csv")
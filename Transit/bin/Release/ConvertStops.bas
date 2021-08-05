OPTION _EXPLICIT

DIM X1, SNum
SNum = 5156

DIM Stops$(1 TO SNum, 1 TO 6)

OPEN "stops.txt" FOR INPUT AS 1
FOR X1 = 1 TO SNum
    INPUT #1, Stops$(X1, 1), Stops$(X1, 2), Stops$(X1, 3), Stops$(X1, 4), Stops$(X1, 5), Stops$(X1, 6)
NEXT
CLOSE #1

OPEN "stops2.txt" FOR OUTPUT AS 1
FOR X1 = 1 TO SNum
    PRINT #1, Stops$(X1, 2); " "; Stops$(X1, 3)
NEXT
CLOSE #1


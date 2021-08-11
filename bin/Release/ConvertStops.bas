OPTION _EXPLICIT

DIM X1, X2, SNum
SNum = 5156

DIM Stops$(1 TO SNum, 1 TO 6), SaveStops$(1 TO SNum, 1 TO 2)

OPEN "stops.txt" FOR INPUT AS 1
FOR X1 = 1 TO SNum
    INPUT #1, Stops$(X1, 1), Stops$(X1, 2), Stops$(X1, 3), Stops$(X1, 4), Stops$(X1, 5), Stops$(X1, 6)

    SaveStops$(X1, 1) = Stops$(X1, 2)
    SaveStops$(X1, 2) = Stops$(X1, 3)

    X2 = INSTR(SaveStops$(X1, 2), " ")

    SaveStops$(X1, 2) = LEFT$(SaveStops$(X1, 2), 1) + "B " + MID$(SaveStops$(X1, 2), X2 + 1)
NEXT
CLOSE #1

OPEN "stops2.txt" FOR OUTPUT AS 1
FOR X1 = 1 TO SNum
    PRINT #1, SaveStops$(X1, 1); " "; SaveStops$(X1, 2)
NEXT
CLOSE #1

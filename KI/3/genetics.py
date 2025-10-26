# Genetic Algorithm approach to solving the N-Queens problem
# Saurav Chhapawala

import board
import random
import time

STATE_NUM = 8

class State:
    def __init__(self):
        self.boardObj = board.Board(QUEENS_NUM)
        #set board fitness based on current state
        self.boardObj.fitness()

        self.state = self.boardObj.getStringRep()
        self.fitness = self.boardObj.get_fit()
        self.normalized = 0

    def setNorm(self, n):
        self.normalized = n

    #function to compare normalization values of States
    def __lt__(self, other):
        return self.normalized < other.normalized


print("N Queens problem solver - Genetic Algotithm")
print("Enter a value for n (default is 5):")
QUEENS_NUM = input()
if QUEENS_NUM == "":
    QUEENS_NUM = 5
else:
    QUEENS_NUM = int(QUEENS_NUM)

#generate the starting boards
boardStates = []
for i in range(STATE_NUM):
    temp = State()
    temp.boardObj.fitness()
    boardStates.append(temp)

print("Starting Boards:")
for s in boardStates:
    s.boardObj.show()

def genetic():
    run = 0
    while True:
        #solution found
        for s in boardStates:
            if s.boardObj.get_fit() == 0:
                return s, run

        fitSum = 0
        #calculate the total of the fitness values
        for s in boardStates:
            fitSum += s.boardObj.get_fit()

        #selection process
        for s in boardStates:
            temp = s.boardObj.get_fit() / fitSum
            s.setNorm(temp)
        #sort the board states ascending by normalized value
        boardStates.sort()

        #boards will get selected depending on how fit they are
        #higher fitness means higher chance of getting selected
        selection = []
        for i in range(STATE_NUM):
            r = random.random()

            if r < boardStates[0].normalized:
                selection.append(boardStates[7])
            elif r < boardStates[0].normalized + boardStates[1].normalized:
                selection.append(boardStates[6])
            elif r < boardStates[0].normalized + boardStates[1].normalized + boardStates[2].normalized:
                selection.append(boardStates[5])
            elif r < boardStates[0].normalized + boardStates[1].normalized + boardStates[2].normalized + boardStates[3].normalized:
                selection.append(boardStates[4])
            elif r < boardStates[0].normalized + boardStates[1].normalized + boardStates[2].normalized + boardStates[3].normalized + boardStates[4].normalized:
                selection.append(boardStates[3])
            elif r < boardStates[0].normalized + boardStates[1].normalized + boardStates[2].normalized + boardStates[3].normalized + boardStates[4].normalized + boardStates[5].normalized:
                selection.append(boardStates[2])
            elif r < boardStates[0].normalized + boardStates[1].normalized + boardStates[2].normalized + boardStates[3].normalized + boardStates[4].normalized + boardStates[5].normalized + boardStates[6].normalized:
                selection.append(boardStates[1])
            else:
                selection.append(boardStates[0])

        #pairing process
        pair1 = [selection[0].boardObj.getStringRep(), selection[1].boardObj.getStringRep()]
        pair2 = [selection[2].boardObj.getStringRep(), selection[3].boardObj.getStringRep()]
        pair3 = [selection[4].boardObj.getStringRep(), selection[5].boardObj.getStringRep()]
        pair4 = [selection[6].boardObj.getStringRep(), selection[7].boardObj.getStringRep()]

        tempList = []
        n = selection[0].boardObj.n_queen

        #cross over process
        #4 groups of 2 for 8 total new states
        randIndex = random.randint(1, n - 1)
        new11 = pair1[0][0:randIndex] + pair1[1][randIndex::]
        new12 = pair1[1][0:randIndex] + pair1[0][randIndex::]

        randIndex = random.randint(1, n - 1)
        new21 = pair2[0][0:randIndex] + pair2[1][randIndex::]
        new22 = pair2[1][0:randIndex] + pair2[0][randIndex::]

        randIndex = random.randint(1, n - 1)
        new31 = pair3[0][0:randIndex] + pair3[1][randIndex::]
        new32 = pair3[1][0:randIndex] + pair3[0][randIndex::]

        randIndex = random.randint(1, n - 1)
        new41 = pair4[0][0:randIndex] + pair4[1][randIndex::]
        new42 = pair4[1][0:randIndex] + pair4[0][randIndex::]

        tempList.append(new11)
        tempList.append(new12)
        tempList.append(new21)
        tempList.append(new22)
        tempList.append(new31)
        tempList.append(new32)
        tempList.append(new41)
        tempList.append(new42)

        #mutation process
        i = 0
        for ele in tempList:
            r = random.randint(0, n)
            if r != 0:
                a = list(ele)
                a[r-1] = str(random.randint(1,n))
                ele = "".join(a)
            selection[i].boardObj.setBoardfromString(ele)
            selection[i].boardObj.fitness()
            i += 1

        state = selection.copy()
        run += 1


startTime = time.time()
finalBoard, run = genetic()
endTime = time.time()

print("Ending Board:")
print("Running time:", (endTime - startTime)*1000, "ms")
print("Runs:", run)
finalBoard.boardObj.show()
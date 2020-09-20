
function startGame(array) {

    let hasWinner;

    const dashBoard =
        [[false, false, false],
        [false, false, false],
        [false, false, false]];

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        let x = Number(element[0]);
        let y = Number(element[2]);

        if (dashBoard[x][y] !== false) {
            console.log('This place is already taken. Please choose another!');
            array.splice(i,1);
            i--;
            continue;
        }

        if (i % 2 === 0) {
            dashBoard[x][y] = 'X';
        } else {
            dashBoard[x][y] = 'O';
        }

        hasWinner = checkForWinner(dashBoard);
        if (hasWinner) {
            let winner = dashBoard[x][y];
            console.log(`Player ${winner} wins!`)
            break;
        }

        let hasFreeSpace = checkForFreeSpace(dashBoard);

        if (!hasFreeSpace) {
            console.log('The game ended! Nobody wins :(');
            break;
        }


    }
        printDashboard(dashBoard);

    function checkForFreeSpace(dashBoard) {
        let hasFreeSpace = false;

        for (let i = 0; i < dashBoard.length; i++) {
            const row = dashBoard[i];
            if (row.includes(false)) {
                hasFreeSpace = true;
                break;
            }
        }
        return hasFreeSpace;
    }
    function checkForWinner(dashBoard) {
        let isWinner = false;

        for (let row = 0; row < dashBoard.length; row++) {
            const element = dashBoard[row];
            let reducer = (accumulator, currentValue) => accumulator + currentValue;
            let rowSequence = element.reduce(reducer);
            if (rowSequence === 'XXX' || rowSequence === 'OOO') {
                isWinner = true;
                return isWinner;

            }

            let colSequence = '';
            for (let col = 0; col < dashBoard.length; col++) {
                const colElement = dashBoard[col][row];
                colSequence += colElement;
            }

            if (colSequence === 'XXX' || colSequence === 'OOO') {
                isWinner = true;
                return isWinner;
            }

        }

        let mainDiagonal = dashBoard[0][0] + dashBoard[1][1] + dashBoard[2][2];
        let secondDiagonal = dashBoard[0][2] + dashBoard[1][1] + dashBoard[2][0];
        if (mainDiagonal === 'XXX' || mainDiagonal === 'OOO') {
            isWinner = true;
        } else if (secondDiagonal === 'XXX' || secondDiagonal === 'OOO') {
            isWinner = true;
        }
        return isWinner;
    }

    function printDashboard(dashBoard){
        dashBoard.forEach(row => {
            console.log(row.join('\t'));
        });
    }
}

startGame(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"])
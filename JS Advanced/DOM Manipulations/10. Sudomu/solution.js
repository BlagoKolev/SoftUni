function solve() {

    let checkButton = document.querySelectorAll('button')[0]
        .addEventListener('click', checkResult);
    let clearButton = document.querySelectorAll('button')[1]
        .addEventListener('click', clearBoard);
    let rows = [...document.querySelectorAll('tbody > tr')]
    let cells = [...document.querySelectorAll('tbody > tr > td > input')]
    let resultField = document.querySelector('div[id="check"] > p');
    let table = document.querySelector('table');


    function checkResult() {
        cells.forEach(x => console.log(x.value))
        let minValue = Number(cells[0].min);
        let maxValue = Number(cells[0].max);

        for (const cell of cells) {
            if (cell.value < minValue || cell.value > maxValue) {
                table.style.border = '2px solid red';
                resultField.style.color = 'red';
                resultField.textContent = "NOP! You are not done yet..."
                return;
            }
        }

        if ((cells[0].value !== cells[1].value && cells[0].value !== cells[2].value)
            && (cells[3].value !== cells[4].value && cells[3].value !== cells[5].value)
            && (cells[6].value !== cells[7].value && cells[6].value !== cells[8].value)
            && (cells[0].value !== cells[3].value && cells[3].value !== cells[6].value)
            && (cells[1].value !== cells[4].value && cells[1].value !== cells[7].value)
            && (cells[2].value !== cells[5].value && cells[2].value !== cells[8].value)
        ) {

            table.style.border = '2px solid green';
            resultField.style.color = 'green';
            resultField.textContent = 'You solve it! Congratulations!';
        }else{
            table.style.border = '2px solid red';
            resultField.style.color = 'red';
            resultField.textContent = "NOP! You are not done yet..."
        }

    }
    function clearBoard() {
        for (const cell of cells) {
            cell.value = '';
            table.style.border = 'none'
        }
        resultField.textContent = '';
    }
}
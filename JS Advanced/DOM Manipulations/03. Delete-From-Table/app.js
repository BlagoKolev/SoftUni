function deleteByEmail() {
let inputField = document.getElementsByTagName('input')[0];
let input = inputField.value;
let cells = [...document.querySelectorAll('tbody > tr > td')];
let outputString = '';
let table = document.querySelector('tbody');
for (const cell of cells) {
    if (cell.textContent === input) {
        let rowToDelete = cell.parentElement;
        table.removeChild(rowToDelete);
        outputString = 'Deleted.';
        break;
    }else{  
        outputString = 'Not found.'
    }
}
let resultDisplay = document.getElementById('result');
resultDisplay.textContent = outputString;
}
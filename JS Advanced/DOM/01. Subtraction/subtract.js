function subtract(){
    let firstValue = document.getElementById('firstNumber').value;
    let secondValue = document.getElementById('secondNumber').value;
    document.getElementById('result').textContent = Number(firstValue) - Number(secondValue);
}
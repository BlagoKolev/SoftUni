function solve() {
 
  let inputField = document.getElementsByTagName('textarea')[0];
  let outputField = document.getElementsByTagName('textarea')[1];
  let generateBtn = document.querySelectorAll('div > button')[0];
  generateBtn.addEventListener('click', generate);
  let buyButton = document.querySelectorAll('div > button')[1];
  buyButton.addEventListener('click', buy);
  let table = document.getElementsByTagName('tbody');
  let originRow = document.querySelector('tbody > tr');
 
  [...document.querySelectorAll('td > input')]
    .forEach(input => {
      input.disabled = false;
    });
 
  function generate() {
    let productArgs = JSON.parse(inputField.value);
for (const furniture of productArgs) {
  let name = furniture.name;
    let price =furniture.price;
    let dFactor = furniture.decFactor;
    let imgsource = furniture.img;
 
    let newTableRow = originRow.cloneNode(true);
    let cells = newTableRow.children;
    cells[0].querySelector('img').setAttribute('src', imgsource);
    cells[0].innerHTML = cells[0].innerHTML.trim();
    cells[1].querySelector('p').textContent = name;
    cells[1].innerHTML = cells[1].innerHTML.trim();
    cells[2].querySelector('p').textContent = price;
    cells[2].innerHTML = cells[2].innerHTML.trim();
    cells[3].querySelector('p').textContent = dFactor;
    cells[3].innerHTML = cells[3].innerHTML.trim();
    cells[4].innerHTML = cells[4].innerHTML.trim();
    table[0].appendChild(newTableRow);
}
 
 
  }
 
  function buy() {
    let checkboxes = [...document.querySelectorAll('td > input')];
    let products = [];
    let totalPrice = 0;
    let factorSum = 0;
    checkboxes.forEach(checkBox => {
      if (checkBox.checked) {
        let parent = checkBox.parentElement;
        let row = parent.parentElement;
        console.log(row)
        console.log(row.children[1])
        let name = row.children[1].querySelector('p').textContent;
        let price = Number(row.children[2].querySelector('p').textContent);
        let factor = Number(row.children[3].querySelector('p').textContent);
 
        products.push(name);
        totalPrice += price;
        factorSum += factor;
      }
    });
    let averageFactor = factorSum / products.length;
    let outputMessage = '';
    outputMessage += `Bought furniture: ${products.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageFactor}`
 
    outputField.textContent = outputMessage;
  }
 
}
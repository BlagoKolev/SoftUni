function solve() {
  let searchBtn = document.getElementById('searchBtn');
  let searchField = document.getElementById('searchField');

  searchBtn.addEventListener('click', onClick);
  let cells = [...document.querySelectorAll('tr > td')];


  function onClick() {
    [...document.getElementsByTagName('tr')].forEach(row => {
      row.removeAttribute('class')
    });
    let request = searchField.value.toLocaleLowerCase();
    
    cells.forEach(cell => {
      if (cell.textContent.toLocaleLowerCase().includes(request)) {
        let row = cell.parentElement;
        row.setAttribute('class', 'select');
      }
    })
    searchField.value = '';
  }
}
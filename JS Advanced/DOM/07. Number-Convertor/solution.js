function solve() {

    const inputField = document.getElementById('input');
    const selectMenuTo = document.getElementById('selectMenuTo');
    const binary = document.createElement('option');
    binary.textContent = 'Binary';
    binary.setAttribute('value', 'binary');
    const hexadecimal = document.createElement('option');
    hexadecimal.setAttribute('value', 'hexadecimal');
    hexadecimal.textContent = 'Hexadecimal';
    selectMenuTo.appendChild(binary);
    selectMenuTo.appendChild(hexadecimal);

    const button = document.getElementsByTagName('button')[0]
        .addEventListener('click', onClick);

    const result = document.getElementById('result');

    function onClick() {
        let value = Number(inputField.value);
                let convResult = '';

        if (selectMenuTo.value === 'binary') {

            convResult = value.toString(2);

        } else if (selectMenuTo.value === 'hexadecimal') {
            convResult = value.toString(16);
        }
        result.value = convResult.toUpperCase();

    }

}
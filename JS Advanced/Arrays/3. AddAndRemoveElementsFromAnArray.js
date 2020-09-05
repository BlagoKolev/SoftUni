function solve(array) {

    let startNum = 1;
    const result = [];

    array.forEach(element => {

        switch (element) {
            case 'add': result.push(startNum); break;
            case 'remove':
                if (result.length > 0) {
                    result.pop();
                }
                break;
        }
        startNum++
    });
   let stringResult = result.length>0 ?result.join('\n'):'Empty';
    console.log(stringResult);
}

solve(['add', 
'add', 
'add', 
'add'])
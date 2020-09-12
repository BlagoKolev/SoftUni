function solve(input){
const rows = [];

    input.reduce((acc,current,i,array) => {
       let employee = JSON.parse(current);
       rows.push(`\t<tr>\n\t\t<td>${employee.name}</td>\n\t\t<td>${employee.position}</td>\n\t\t<td>${employee.salary}</td>\n\t</tr>`)
    },{})
   console.log('<table>');
    console.log(rows.join('\n'));
    console.log('</table>')
    
}
solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}'] )
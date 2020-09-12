function solve(input) {

    const register = {};

    for (const line of input) {
        const [system, component, subcomponent] = line.split(' | ');

        if (!register.hasOwnProperty(system)) {
            register[system] = {};
        }
        if (!register[system].hasOwnProperty(component)) {
            register[system][component] = [];
        }
        register[system][component].push(subcomponent);
    }
    //console.log(Object.entries(register))
    let sortedSystems = Object.entries(register).sort((a, b) => {
        return Object.keys(b[1]).length - Object.keys(a[1]).length
            || a[0].localeCompare(b[0])
    }).forEach(([system, component]) => {
        console.log(system);
        Object.entries(component).sort((a, b) => b[1].length - a[1].length)
            .forEach(([name, sub]) => {
                console.log(`|||${name}`);
                sub.forEach(x => {
                    console.log(`||||||${x}`)
                })
            })

    });

}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'])
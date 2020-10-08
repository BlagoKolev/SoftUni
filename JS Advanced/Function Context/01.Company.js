class Company {

    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {

        let userArgs = [username, salary, position, department];

        for (let i = 0; i < userArgs.length; i++) {
            let element = userArgs[i];
            if (typeof element === 'number') {
                if (element < 0) {
                    throw new Error('Invalid input!')
                }
            } else {
                if (element === '' || element === undefined || element === null) {
                    throw new Error('Invalid input!');
                }
            }
        }
        const user = { username: username, salary: Number(salary), position: position, department: department };

        if (!this.departments.hasOwnProperty(user.department)) {
            this.departments[user.department] = [];
        }
        this.departments[user.department].push(user)



        return `New employee is hired. Name: ${user.username}. Position: ${user.position}`

    }

    bestDepartment() {

        let bestAverageSalary = 0;
        let bestDepartment = '';
        for (const department in this.departments) {

            const element = this.departments[department];
            let currentSum = 0;
            element.forEach(x => {
                currentSum += x.salary;
                
            });
            if (currentSum /Object.keys(this.departments[department]).length > bestAverageSalary) {
                bestAverageSalary = currentSum/Object.keys(this.departments[department]).length ;
                bestDepartment = department;
            }
        }

       
        let output ='';
        output+=`Best Department is: ${bestDepartment}\n`;
        output+= `Average salary: ${bestAverageSalary.toFixed(2)}\n`;

        for (const employee of this.departments[bestDepartment]
            .sort((a,b) => b.salary - a.salary
            || (a.username).localeCompare(b.username))) {
            output +=`${employee.username} ${employee.salary} ${employee.position}\n`
        };
        return output.trim();
    }
}

function solve() {
    let c = new Company();
    c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
    c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
    c.addEmployee("Slavi", 500, "dyer", "Construction");
    c.addEmployee("Stan", 2000, "architect", "Construction");
    c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
    c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
    c.addEmployee("Gosho", 1350, "HR", "Human resources");
    console.log(c.bestDepartment());
}
solve();
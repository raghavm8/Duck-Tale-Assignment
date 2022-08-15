class Employee {
    empId: Number
    empName: string
    managerId: Number
    empSalary: Number

    constructor(empId: Number, empName: string, managerId: Number, empSalary: Number) {
        this.empId = empId;
        this.empName = empName;
        this.managerId = managerId;
        this.empSalary = empSalary;
    }
}

export default Employee;
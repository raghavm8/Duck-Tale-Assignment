import axios, { AxiosResponse } from "axios";
import { useState, useEffect } from "react";
import AxiosInstance from "./AxiosInstance";
import DisplayTask from "./Components/DisplayTask";
import EmployeeTable from './Components/EmployeeTable'
import './custom.css'
import Employee from "./EmployeeModel";

const App = () => {
    const [employees, setEmployees] = useState<Employee[]>([]);
    const [task1, setTask1] = useState<[]>([]);
    const [task2, setTask2] = useState<[]>([]);
    const [task3, setTask3] = useState<[]>([]);
    const [task4, setTask4] = useState<[]>([]);

    const FillEmployeeData = () => {
        AxiosInstance.get('/')
            .then((response: AxiosResponse) => {
                const employees: Employee[] = response.data;
                setEmployees(employees);
            })
            .catch((error) => {
                console.error(error.message);
            })
    }

    const FillTasks = async () => {
        const reqOne = AxiosInstance.get('/Task1');
        const reqTwo = AxiosInstance.get('/Task2');
        const reqThree = AxiosInstance.get('/Task3');
        const reqFour = AxiosInstance.get('/Task4');

        await axios.all([reqOne, reqTwo, reqThree, reqFour])
            .then(axios.spread((...responses) => {
                setTask1(responses[0].data);
                setTask2(responses[1].data);
                setTask3(responses[2].data);
                setTask4(responses[3].data);
            }))
            .catch((errors) => {
                console.error(errors.message);
            })
    }

    const headers = [
        { header: "EmpId" },
        { header: "EmpName" },
        { header: "ManagerId" },
        { header: "EmpSalary" }
    ]

    useEffect(() => {
        FillEmployeeData();
        FillTasks();
    }, [task1, task2, task3, task4]);

    return (
        <div className="mainContainer">
            <EmployeeTable data={employees} headers={headers} />
            {task1 !== undefined ? <DisplayTask heading={"Task1"} taskData={task1} />:<></>}
            {task2 !== undefined ? <DisplayTask heading={"Task2"} taskData={task2} />:<></>}
            {task3 !== undefined ? <DisplayTask heading={"Task3"} taskData={task3} />:<></>}
            {task4 !== undefined ? <DisplayTask heading={"Task4"} taskData={task4} />:<></>}
        </div>
    );
}

export default App;
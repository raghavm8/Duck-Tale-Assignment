import './EmployeeTableStyle.css'

const EmployeeTable = (props) => {
    const { data, headers } = props;
    return (
        <div>
            <table>
                <thead>
                    <tr>
                        {
                            headers.map((head, index) => (
                                <th key={index}>
                                    {head.header}
                                </th>
                            ))
                        }
                    </tr>
                </thead>
                <tbody>
                    {
                        data.map((row, index) => (
                            <tr key={index}>
                                <td>{row.empId}</td>
                                <td>{row.empName}</td>
                                <td>{row.managerId !== 0 ? row.managerId : "Null"}</td>
                                <td>{row.empSalary}</td>
                            </tr>
                        ))

                    }
                </tbody>
            </table>
        </div>
    )
}

export default EmployeeTable;
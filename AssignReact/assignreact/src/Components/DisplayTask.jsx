
const DisplayTask = (props) => {
    const { heading, taskData } = props;
    return (
        <div>
            <h4>{heading}</h4>
            <ul>
                {
                    Object.entries(taskData).map(([key, value]) => (
                        <li key={key}>{key}: {value}</li>
                    ))
                }
            </ul>
        </div>
    );
}

export default DisplayTask;
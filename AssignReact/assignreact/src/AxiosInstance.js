import axios from "axios";

const AxiosInstance = axios.create({
    baseURL: 'https://localhost:7214/api/Employee',
});

export default AxiosInstance;
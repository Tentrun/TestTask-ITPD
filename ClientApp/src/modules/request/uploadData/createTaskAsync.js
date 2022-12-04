import API_ADDRESSES from "../../../config/staticEndpoints";
import axios from "axios";

async function createTaskAsync(projectId, TaskName, StartDate, CancelDate) {
    const response = await axios({
        method: 'post',
        url: `${API_ADDRESSES.API_URL_TASK_CREATE}?ProjectID=${projectId}&TaskName=${TaskName}&StartDate=${StartDate}&CancelDate=${CancelDate}`,
        headers: { },
    });
    return response;
}
export default createTaskAsync;



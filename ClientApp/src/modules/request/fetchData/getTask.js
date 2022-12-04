import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getTask(taskId){
    const response = await axios({
        method: 'get',
        url: `${API_ADDRESSES.API_URL_TASK_GET_BY_ID}?id=${taskId}`,
        headers: { },
    });
    return response;
}
export default getTask;
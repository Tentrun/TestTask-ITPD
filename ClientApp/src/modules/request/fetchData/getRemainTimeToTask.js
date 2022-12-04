import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getRemainTimeToTask(taskId){
    const response = await axios({
        method: 'get',
        url: `${API_ADDRESSES.API_URL_TASK_REMAIN_TIME}?taskId=${taskId}`,
        headers: { },
    });
    return response;
}
export default getRemainTimeToTask;
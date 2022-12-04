import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getTaskDescriptions(taskId){
    const response = await axios({
        method: 'get',
        url: `${API_ADDRESSES.API_URL_TASK_COMMENT_GET_BY_PROJECT_ID}?id=${taskId}`,
        headers: { },
    });
    return response;
}
export default getTaskDescriptions;
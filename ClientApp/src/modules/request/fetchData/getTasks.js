import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getTasks(projectId){
    const response = await axios({
        method: 'get',
        url: `${API_ADDRESSES.API_URL_TASKS_GET_BY_PROJECT}?id=${projectId}`,
        headers: { },
    });
    return response;
}
export default getTasks;
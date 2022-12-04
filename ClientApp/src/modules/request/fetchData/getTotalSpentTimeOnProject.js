import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getTotalSpentTimeOnProject(projectId){
    const response = await axios({
        method: 'get',
        url: `${API_ADDRESSES.API_URL_TASKS_TOTAL_SPENT_TIME}?projectId=${projectId}`,
        headers: { },
    });
    return response;
}
export default getTotalSpentTimeOnProject;
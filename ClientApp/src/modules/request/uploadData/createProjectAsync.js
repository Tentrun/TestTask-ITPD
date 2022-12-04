import API_ADDRESSES from "../../../config/staticEndpoints";
import axios from "axios";

async function createProjectAsync(projectName) {
    const response = await axios({
        method: 'post',
        url: `${API_ADDRESSES.API_URL_PROJECT_CREATE}?projectName=${projectName}`,
        headers: { },
    });
    return response;
}
export default createProjectAsync;



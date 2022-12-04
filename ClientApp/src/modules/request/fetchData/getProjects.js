import axios, { AxiosResponse, AxiosError } from 'axios'
import API_ADDRESSES from "../../../config/staticEndpoints";

async function getProjects(){
    const response = await axios({
        method: 'get',
        url: API_ADDRESSES.API_URL_PROJECTS_GET,
        headers: { },
    });
    return response;
}
export default getProjects;

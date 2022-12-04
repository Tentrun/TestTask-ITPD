import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function editTask(taskEntity){
    const response = await axios({
        method: 'post',
        url: `${API_ADDRESSES.API_URL_TASK_EDIT}?Id=${taskEntity.id}&TaskName=${taskEntity.taskName}&StartDate=${taskEntity.startDate}&CancelDate=${taskEntity.cancelDate}`,
        headers: { },
    });
    return response;
}
export default editTask;
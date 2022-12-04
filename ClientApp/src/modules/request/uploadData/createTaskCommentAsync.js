import API_ADDRESSES from "../../../config/staticEndpoints";
import axios from "axios";

async function createTaskCommentAsync(TaskId, content, isFile){
    const data = new FormData();
    data.append('TaskId', TaskId);
    data.append('Content', `${content}`);

    if (isFile){
        data.append('CommentType', 1);
    }

    if(!isFile){
        data.append('CommentType', 0);
    }

    const response = await axios({
        method: 'post',
        url: `${API_ADDRESSES.API_URL_TASK_COMMENT_CREATE}`,
        headers: { "Content-Type": "multipart/form-data" },
        data : data
    });
    return response;
}
export default createTaskCommentAsync;
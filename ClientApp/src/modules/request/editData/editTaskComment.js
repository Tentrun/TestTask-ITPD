import axios from "axios";
import API_ADDRESSES from "../../../config/staticEndpoints";

async function editTaskComment(commentEntity, isFile){
    const data = new FormData();
    data.append('TaskId', commentEntity.taskId);
    data.append('Content', commentEntity.content);

    if (isFile){
        data.append('CommentType', 1);
    }

    if(!isFile){
        data.append('CommentType', 0);
    }

    const response = await axios({
        method: 'post',
        url: `${API_ADDRESSES.API_URL_TASK_COMMENT_EDIT}`,
        headers: { "Content-Type": "multipart/form-data" },
        data : data
    });
    return response;
}
export default editTaskComment;
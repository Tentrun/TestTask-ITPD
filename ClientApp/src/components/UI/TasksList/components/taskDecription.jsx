import React, {useEffect, useState} from 'react';
import getTaskDescription from "../../../../modules/request/fetchData/getTaskDescription";
import get_unicode_fromBase64 from "../../../../modules/base64_modules/modules/get_unicode_fromBase64";

const TaskDecription = ({taskId}) => {
    const [description, setDescription] = useState();

    useEffect(() => {
        async function getData(){
            const response = await getTaskDescription(taskId);
            if (response.status === 200) {
                setDescription(response.data.content);
            }
        }
        getData()
    }, [])

    return (
        <td>
            {description && <div>{get_unicode_fromBase64(description)}</div>}
        </td>
    );
};


export default TaskDecription;
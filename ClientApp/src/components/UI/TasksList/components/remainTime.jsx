import React, {useEffect, useState} from 'react';
import getRemainTimeToTask from "../../../../modules/request/fetchData/getRemainTimeToTask";

const RemainTime = ({taskId}) => {
    const [time, setTime] = useState();

    useEffect(() => {
        async function getData(){
            const response = await getRemainTimeToTask(taskId);
            if (response.status === 200) {
                setTime(response.data);
            }
        }
        getData();
    }, [])

    return (
        <td>
            {time}
        </td>
    );
};

export default RemainTime;
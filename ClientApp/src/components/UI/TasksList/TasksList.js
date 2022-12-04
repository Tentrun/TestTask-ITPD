import React, {useEffect, useState} from 'react';
import {NavLink, Table} from "react-bootstrap";
import TaskCreateModal from "../modal/TaskCreateModal";
import SumbitButton from "../button/SumbitButton";
import getTasks from "../../../modules/request/fetchData/getTasks";
import RemainTime from "./components/remainTime";
import TaskDecription from "./components/taskDecription";
import {useNavigate} from "react-router-dom";

const TasksList = ({projectId, totalTimeSpent, tasks, setTasks}) => {
    const [showModal, setShowModal] = useState(false);

    const navigate = useNavigate();
    const handleShow = () => setShowModal(true);

    const updateTasks = async() => {
        let response = await getTasks(projectId);
        setTasks(response.data);
    }

    useEffect( () => {
         updateTasks();
    }, [])

    const editTaskRoute = (taskId) => {
        navigate('/EditTask', { state: { taskId: taskId} });
    }

    return (
        <div className='m-2'>
            <h2 className='d-flex justify-content-center'>Tasks list</h2>
            {tasks && tasks.length === 0 && (
                <h5 className='d-flex justify-content-center'> Task for current project is missing</h5>
            )}

            <div className='d-flex justify-content-center'>
                <SumbitButton onClick={handleShow}>
                    Create task
                </SumbitButton>
            </div>

            <TaskCreateModal updateTasks={updateTasks} show={showModal} setShowModal={setShowModal}></TaskCreateModal>

            <h5>Total time spent : {totalTimeSpent}</h5>
            <Table striped bordered hover className='m-3'>
            <thead>
            <tr>
                <th>#</th>
                <th>ID</th>
                <th>Name</th>
                <th>Start Date</th><th>Cancel Date</th>
                <th>Remain time</th>
                <th>Description</th>
            </tr>
            </thead>
            <tbody>
            {tasks &&
                tasks.map((task, idx) => {
                    return(
                        <tr style={{cursor: "pointer"}} key={task.id} onClick={e => editTaskRoute(task.id)}>
                            <td>{idx + 1}</td>
                            <td>{task.id}</td>
                            <td>{task.taskName}</td>
                            <td>{task.startDate && new Date(Date.parse(task.startDate)).toLocaleString()}</td>
                            <td>{task.cancelDate && new Date(Date.parse(task.cancelDate)).toLocaleString()}</td>
                            <RemainTime taskId={task.id}></RemainTime>
                            <TaskDecription taskId={task.id}></TaskDecription>
                        </tr>
                    )
                }
            )}
            </tbody>
        </Table>
        </div>
    );
};

export default TasksList;
import React, {useEffect, useState} from 'react';
import {useLocation, useNavigate} from "react-router-dom";
import {Form} from "react-bootstrap";
import Button from "react-bootstrap/Button";
import getTask from "../../modules/request/fetchData/getTask";
import getTaskDescription from "../../modules/request/fetchData/getTaskDescription";
import editTask from "../../modules/request/editData/editTask";
import editTaskComment from "../../modules/request/editData/editTaskComment";
import getAsBytes from "../../modules/base64_modules/getAsBytes";

const EditTask = () => {
    const {state} = useLocation();
    const {taskId} = state; // Read values passed on state

    const [isCompleted, setIsCompleted] = useState(false);

    const [task, setTask] = useState();
    const [taskDescription, setTaskDescription] = useState();

    //fileForm
    const [file, setFile] = useState(undefined);
    //checkbox state
    const [isFile, setIsFile] = useState(false);

    const navigate = useNavigate();

    useEffect( () => {
        async function getInfo() {
            const response = await getTask(taskId);
            setTask(response.data)

            if (response.status === 200){
                const response = await getTaskDescription(taskId);
                setTaskDescription(response.data)
            }
        }
        getInfo()
    }, [])

    const uploadFile = async(e) =>{
        let file = e.target.files[0];
        setFile(file);
    }

    const handleSubmit = async(e) => {
        e.preventDefault();

        var taskEntity = task;
        taskEntity.startDate = e.target.StartDate.value;
        taskEntity.taskName = e.target.TaskName.value;

        if (!isCompleted){
            taskEntity.cancelDate = e.target.CancelDate.value;
        }
        else{
            var currentdate = new Date();
            var datetime = (currentdate.getMonth()+1)  + "."
                + currentdate.getDate() + "."
                + currentdate.getFullYear() + " "
                + currentdate.getHours() + ":"
                + currentdate.getMinutes()

            taskEntity.cancelDate = datetime;
        }

        if(isNaN(Date.parse(taskEntity.cancelDate)) || Date.parse(taskEntity.startDate) <= Date.parse(taskEntity.cancelDate)){
            var response = await editTask(taskEntity);
            if (response.status === 200){
                var commentEntity = taskDescription;
                if (isFile){
                    commentEntity.content = await getAsBytes(file, isFile);
                }
                if (!isFile){
                    commentEntity.content = await getAsBytes(e.target.Description.value, isFile);
                }
                var response = await editTaskComment(commentEntity, isFile);
                navigate('/DashBoard');
            }
            else{
                console.log('Unable to edit task')
            }
        }
        else{
            alert('Cancel Date cannot be greater that Start Date');
        }
    }

    return (
        <div>
            {task && taskDescription && (
                <Form onSubmit={handleSubmit} className='d-xl-grid  justify-content-center'>
                    <Form.Group className="mb-3" controlId="TaskName">
                        <Form.Label>Task name</Form.Label>
                        <Form.Control defaultValue={task.taskName} type="text" placeholder="Task name" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="StartDate">
                        <Form.Label>Start Date</Form.Label>
                        <Form.Control defaultValue={task.startDate} type="datetime-local" placeholder="Cancel Date" />
                    </Form.Group>

                    <Form.Group hidden={isCompleted} className="mb-3" controlId="CancelDate">
                        <Form.Label>Cancel Date</Form.Label>
                        <Form.Control disabled={isCompleted} defaultValue={task.cancelDate} type="datetime-local" placeholder="Cancel Date" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="isCompleted">
                        <Form.Check type="checkbox" checked={isCompleted} onChange={(e) => setIsCompleted(e.currentTarget.checked)} label="Is complete task" />
                    </Form.Group>

                    <Form.Group hidden={isFile} className="mb-3" controlId="Description">
                        <Form.Label>Description</Form.Label>
                        <Form.Control required defaultValue={undefined} type="text" placeholder="Description" disabled={isFile}/>
                    </Form.Group>

                    {isFile && (
                        <Form.Group className="mb-3" controlId="UploadFile">
                            <Form.Label>Description</Form.Label>
                            <Form.Control required onChange={e => uploadFile(e)} type="file" placeholder="Put files here" disabled={!isFile} accept='.txt,.doc'/>
                        </Form.Group>
                    )}

                    <Form.Group className="mb-3" controlId="isFile">
                        <Form.Check type="checkbox" checked={isFile} onChange={(e) => setIsFile(e.currentTarget.checked)} label="Is file description" />
                    </Form.Group>

                    <Button variant="primary" type='submit'>
                        Edit task
                    </Button>
                </Form>
            )}
        </div>
    );
};

export default EditTask;
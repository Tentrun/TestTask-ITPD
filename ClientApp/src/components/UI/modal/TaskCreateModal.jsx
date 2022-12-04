import React, {useState} from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import SelectDropdown from "../dropdown/SelectDropdown";
import Form from 'react-bootstrap/Form';
import Row from "react-bootstrap/Row";
import createTaskAsync from "../../../modules/request/uploadData/createTaskAsync";
import getAsBytes from "../../../modules/base64_modules/getAsBytes";
import createTaskCommentAsync from "../../../modules/request/uploadData/createTaskCommentAsync";
import {logger} from "workbox-core/_private";

const TaskCreateModal = ({show, setShowModal, updateTasks}) => {
    const [selectedProject, setSelectedProject] = useState(undefined);

    //fileForm
    const [file, setFile] = useState(undefined);
    //checkbox state
    const [isFile, setIsFile] = useState(false);

    const uploadFile = async(e) =>{
        let file = e.target.files[0];
        setFile(file);
    }

    const handleClose = (e) => {
        setSelectedProject(undefined);
        setIsFile(false);
        setShowModal(false)
    };

    const handleChange = async (projectId) => {
        setSelectedProject(projectId)
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        if(selectedProject !== undefined){
            if (isNaN(Date.parse(e.target.CancelDate.value)) || Date.parse(e.target.StartDate.value) <= Date.parse(e.target.CancelDate.value)) {
                var response = await createTaskAsync(selectedProject, e.target.TaskName.value, e.target.StartDate.value, e.target.CancelDate.value);
                switch (response.status)
                {
                    case 200:
                        console.log(isFile)
                        if (isFile) {
                            var commentResponse = await createTaskCommentAsync(response.data.id, await getAsBytes(file, isFile), isFile);
                        }
                        if (!isFile) {
                            var commentResponse = await createTaskCommentAsync(response.data.id, await getAsBytes(e.target.Description.value, isFile), isFile);
                        }
                        updateTasks();
                        handleClose();
                        break;

                    default:
                        console.log('Unable to create a task')
                        console.log(`Server returned status ${response.status}`)
                        break;
                }
            }
            else{
                alert('Cancel Date cannot be greater that Start Date');
            }
        }
        else {
            handleClose();
        }
    }

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Create task</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                    <Form.Group className="mb-3" controlId="ProjectName">
                        <Form.Label>Project</Form.Label>
                        <SelectDropdown onChange={handleChange} setProjectEvent={setSelectedProject}></SelectDropdown>
                    </Form.Group>

                    {selectedProject && (
                        <Row>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group className="mb-3" controlId="TaskName">
                                    <Form.Label>Task name</Form.Label>
                                    <Form.Control required type="text" placeholder="Task name" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="StartDate">
                                    <Form.Label>Start Date</Form.Label>
                                    <Form.Control defaultValue={undefined} type="datetime-local" placeholder="Start Date" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="CancelDate">
                                    <Form.Label>Cancel Date</Form.Label>
                                    <Form.Control defaultValue={undefined} type="datetime-local" placeholder="Cancel Date" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="isFile">
                                    <Form.Check type="checkbox" checked={isFile} onChange={(e) => setIsFile(e.currentTarget.checked)} label="Is file description" />
                                </Form.Group>

                                {isFile && (
                                    <Form.Group className="mb-3" controlId="UploadFile">
                                        <Form.Label>File Description</Form.Label>
                                        <Form.Control required onChange={e => uploadFile(e)} type="file" placeholder="Put files here" disabled={!isFile} accept='.txt,.doc'/>
                                    </Form.Group>
                                )}

                                <Form.Group className="mb-3" controlId="Description">
                                    <Form.Label>Description</Form.Label>
                                    <Form.Control required defaultValue={undefined} type="text" placeholder="Description" disabled={isFile}/>
                                </Form.Group>

                                <Button className='d-flex align-content-center' variant="primary" type="submit">
                                    Create task
                                </Button>
                            </Form>
                        </Row>
                    )}
            </Modal.Body>
        </Modal>
    );
};

export default TaskCreateModal;
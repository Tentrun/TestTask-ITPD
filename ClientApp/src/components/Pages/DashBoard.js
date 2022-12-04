import React, {useState} from 'react';
import SumbitButton from "../UI/button/SumbitButton";
import InputField from "../UI/input/InputField";
import SelectDropdown from "../UI/dropdown/SelectDropdown";
import createProjectAsync from "../../modules/request/uploadData/createProjectAsync";
import getTotalSpentTimeOnProject from "../../modules/request/fetchData/getTotalSpentTimeOnProject";
import TasksList from "../UI/TasksList/TasksList";
import getTasks from "../../modules/request/fetchData/getTasks";

function DashBoard(){
    //create state
    const [projectName, setProjectName] = useState()
    //selected project
    const [projectId, setProjectId] = useState()
    //Total time
    const[totalTimeSpent, setTotalTimeSpent] = useState();
    //tasks array
    const [tasks,setTasks] = useState([]);

    const handleChange = async (projectId) => {
        setProjectId(projectId)
        await updateTasks(projectId);
        await getTotalSpentTime(projectId);
    }

    const getTotalSpentTime = async(projectId) => {
        var response = await getTotalSpentTimeOnProject(projectId)
        await setTotalTimeSpent(response.data);
    }

    const updateTasks = async(projectId) =>{
        const response = await getTasks(projectId);

        if (response.status === 200) {
            await setTasks(response.data);
        }

        if (response.status === 204){
            if (tasks.length > 0) {
                await setTasks([]);
            }
            console.log(`Tasks from project with ID "${projectId}" is missing`)
        }
    }

    const addNewProject = async (e) => {
        e.preventDefault()
        const response = await createProjectAsync(projectName);

        if (response.status === 201) {
            alert(`Project ${projectName} created`)
            console.log('Project created');
        }
        else {
            console.log(`Unable to create a project with name "${projectName}"`)
            console.log(`Server returned status code ${response.status}`)
        }
    }

    return (
        <div>
            <h4>Project ID : {projectId}</h4>
            <form>
                <InputField
                    value={projectName}
                    onChange={e => setProjectName(e.target.value)}
                    type="text"
                    placeholder="Project name"
                    required="true"/>
                <SumbitButton onClick={addNewProject}>Create project</SumbitButton>
            </form>
            <SelectDropdown onChange={handleChange} setProjectEvent={setProjectId}></SelectDropdown>
            {projectId &&(
                <TasksList totalTimeSpent={totalTimeSpent} tasks={tasks} setTasks={setTasks} projectId={projectId}></TasksList>
            )}
        </div>
    );
}

export default DashBoard;
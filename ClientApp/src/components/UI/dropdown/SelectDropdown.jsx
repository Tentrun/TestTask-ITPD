import Form from 'react-bootstrap/Form';
import React, {useState} from 'react';
import getProjects from "../../../modules/request/fetchData/getProjects";


const SelectDropdown = ({onChange}) => {
    const [projects, setProjects] = useState([
    ])

    const fetchProjects = async() => {
        var response = await getProjects()

        if (response.status === 200) {
            setProjects(response.data)
        }
        else {
            console.log(`Unable to get projects`);
            console.log(`Server returned status code ${response.status}`);
        }
    }

    React.useEffect(() => {
        fetchProjects()
    }, [])


    return (
        <Form.Control as="select" className='d-flex justify-content-center' onClick={fetchProjects} onChange={e => onChange(e.target.value)}>
            <option selected disabled className='text-info' value={undefined}>Select project</option>
            {projects &&
                projects.map(project =>
            <option key={project.id} value={project.id} label={project.projectName}></option>
            )}
        </Form.Control>
    );
};

export default SelectDropdown;
import React from 'react';
import classes from "./InputField.module.css";

const InputField = (props) => {
    return (
        <input className={classes.inputField} {...props}/>
    );
};

export default InputField;
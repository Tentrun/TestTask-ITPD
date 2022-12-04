import React from 'react';
import classes from "./SumbitButton.module.css";

const SumbitButton = ({children ,...props}) => {
    return (
        <button  {...props} className={classes.sumbitButton}>
            {children}
        </button>
    );
};

export default SumbitButton;
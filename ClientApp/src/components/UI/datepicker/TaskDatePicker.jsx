import React, {useState} from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const TaskDatePicker = ({onChangeHandle, date}) => {
    return (
        <DatePicker 
        selected = {date}
        onChange = {(date) => onChangeHandle(date)}
        isClearable
        placeholderText="Select start date"
        />
    );
};

export default TaskDatePicker;
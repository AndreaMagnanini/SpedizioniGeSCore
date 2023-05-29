import React, {useState} from "react";
import {TextField} from "@material-ui/core";
import {makeStyles} from "@material-ui/core";

const useStyles = makeStyles({
    field: {
        marginTop: 20,
        marginBottom: 20,
        display: 'block'
    }
})

function BasicField(props) {
    const classes = useStyles()
    const [title, setTitle] = useState('')
    const [titleError, setTitleError] = useState(false)
    const handleSubmit = (e) => {
        e.preventDefault()
        setTitleError(false)
        
        if(title === ''){
            setTitleError(true)
        }
        if(title) {
            console.log(title)
        }
    }
    return (
        <form noValidate autoComplete="off" onSubmit={handleSubmit}>
            <TextField
                onChange={(e) => setTitle(e.target.value)}
                className={classes.field}
                label="Title"
                variant="filled"
                color="primary"
                error={titleError}/>
        </form>
    );
}

export default BasicField;
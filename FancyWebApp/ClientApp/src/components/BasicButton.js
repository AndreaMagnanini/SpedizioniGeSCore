import React from 'react';
import {Button} from "@material-ui/core";
import AppleIcon from '@material-ui/icons/Apple';
import {makeStyles} from "@material-ui/core";

const useStyles = makeStyles({
    btn: {
        fontSize: 60,
        backgroundColor: 'violet',
        '&:hover': {
            backgroundColor: 'blue'
        }
    }
})
function BasicButton(props) {
    const classes = useStyles()

    return (
        <Button className={classes.btn}
            variant="contained"
            size="large"
            color="primary"
            endIcon={<AppleIcon color="secondary" fontSize="large"/>}
            disableElevation>
            <h3>
                button
            </h3>
        </Button>
    );
}

export default BasicButton;
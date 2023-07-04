import React from 'react';
import {makeStyles} from "@material-ui/core";

const useStyles = makeStyles({
    container: {
        position: "relative",
        width: "48px",
        height: "48px",
        borderRadius: "100%",
        overflow: "hidden",
        boxShadow: "inset 0px 0px 0px 6px #eeeeee",

    },
    spinner: {
        animationName: "$spin",
        animationDuration: "1s",
        animationTimingFunction: "linear",
        animationIterationCount: "infinite",
        display: "block",
        width:" 100%",
        height: "100%",
        clip: "rect(0, 48px, 48px, 24px)",
        position: "absolute",
        borderRadius: "100%",
        boxShadow: "inset 0px 0px 0px 6px #D41217",
    },
    "@keyframes spin": {
        from: { transform: "rotate(0deg)" },
        to: { transform: "rotate(360deg)" }
    }

});
const CircularProgress = () => {
    const classes = useStyles();
    return (
        <div className={classes.container}>
            <div className={classes.spinner}></div>
        </div>
    );
};

export default CircularProgress;
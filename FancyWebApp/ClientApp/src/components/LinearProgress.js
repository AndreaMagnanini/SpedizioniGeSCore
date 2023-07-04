import React from 'react';
import {makeStyles} from "@material-ui/core";
const useStyles = makeStyles({
    container: {
        width: "100%",
        height: "6px",
        display: "block",
        overflow: "hidden",
        backgroundColor: "#D4121740",
        opacity: "100%"
    },
    linearLoader: {
        animation: "$linearLoading",
        position: "relative",
        "&::after":{
            content: 'none',
            height: "4px",
            width: "50%",
            backgroundColor: "#D41217ff",
            position: "absolute",
            animation: "$linearLoading",
            animationDuration: "3s",
            animationIterationCount: "infinite",
            animationTimingFunction: "linear"
        },
        "&::before": {
            content: 'none',
            height: "6px",
            width: "50%",
            backgroundColor: "#D41217ff",
            position: "absolute",
            animation: "$linearLoading",
            animationDuration: "3s",
            animationIterationCount: "infinite",
            animationDelay: "1.5s",
            animationTimingFunction: "linear"
        },
    },
    "@keyframes linearLoading": {
        "0%": {
            transform: "translate(-100%, 0px)",
        },
        "100%": {
            transform: "translate(200%, 0px)",
        }
    }

});
const LinearProgress = () => {
    const classes = useStyles();
    return (
        <div className={classes.container}>
            <div className={classes.linearLoader}>
            </div>
        </div>

    );
};

export default LinearProgress;

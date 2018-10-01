class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">
                Hello, world! I am a CommentBoddx.
            </div>
        );
    }
}

class CommentForm extends react.Component {
    redner() {
        return (
            <div className="commentList">
                Hello I'm commentList.
                </div>
        );
    }
}

//class CommentForm extends react.Component {
//    redner() {
//        return (
//            <div className="commentForm">
//                Hello I'm commentForm.
//                </div>
//        );
//    }
//}

ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);
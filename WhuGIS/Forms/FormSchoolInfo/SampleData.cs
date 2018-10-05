using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WhuGIS.Forms.FormSchoolInfo
{
    /// <summary>
    /// 示例数据 避免不可抗力...
    /// </summary>
    public static class SampleData
    {

        #region ofo示例数据
        public const string ofosample = @"{
    'errorCode': 200,
    'msg': '操作成功',
    'values': {
        'info': {
            'redPacketAreas': [],
            'time': 1,
            'cars': [
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36122986102966,
                    'lat': 30.526899783185314,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3614440811175,
                    'lat': 30.526174893553822,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36151929058076,
                    'lat': 30.52734346609268,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36189472752787,
                    'lat': 30.526799819216208,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3610616267301,
                    'lat': 30.527594609000122,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36029912910878,
                    'lat': 30.526769052537585,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36075319101559,
                    'lat': 30.525850106410502,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36103142251726,
                    'lat': 30.52776420557798,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36194771280752,
                    'lat': 30.525833591036747,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36113073619117,
                    'lat': 30.5281233187409,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36248254572662,
                    'lat': 30.52741095430517,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36102492152742,
                    'lat': 30.528196005659858,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35996106692477,
                    'lat': 30.52579836171395,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36253647178846,
                    'lat': 30.5257585042598,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36084018680816,
                    'lat': 30.52509957016843,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36112073472962,
                    'lat': 30.528478718223635,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36078188875463,
                    'lat': 30.52499936881646,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36069997754487,
                    'lat': 30.524980358644175,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36188055597889,
                    'lat': 30.52504022737665,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36272671094089,
                    'lat': 30.525684781724383,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3630552268341,
                    'lat': 30.52676464975253,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36056480820989,
                    'lat': 30.524977083124785,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36318535394001,
                    'lat': 30.52631270796246,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.363216456215,
                    'lat': 30.527031990025442,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36248234834525,
                    'lat': 30.525144219980458,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36009117494419,
                    'lat': 30.525018323046876,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35919005937006,
                    'lat': 30.526281247293266,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36246731992746,
                    'lat': 30.525041162875997,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3632164878393,
                    'lat': 30.527395107996757,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3631853245822,
                    'lat': 30.525975598798336,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36112852599534,
                    'lat': 30.524590873064124,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36274269264598,
                    'lat': 30.52523766257548,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36022301290573,
                    'lat': 30.524759299712343,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36325455800122,
                    'lat': 30.527643248436046,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35967862175089,
                    'lat': 30.525082666442962,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36302610768546,
                    'lat': 30.525415757598083,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36047284669218,
                    'lat': 30.52460222990177,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36023141404931,
                    'lat': 30.524695200601517,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36334566280807,
                    'lat': 30.52751334913262,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36010653071311,
                    'lat': 30.528872598823213,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35946111167557,
                    'lat': 30.52503200875794,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35945901140272,
                    'lat': 30.52502280848979,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35940340412334,
                    'lat': 30.52502360190348,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35942750728513,
                    'lat': 30.524985904679305,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36194758390862,
                    'lat': 30.524353113163066,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36209367260075,
                    'lat': 30.5243911334458,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36351389661446,
                    'lat': 30.527742687140087,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36261845456009,
                    'lat': 30.524635341559918,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36249273000801,
                    'lat': 30.524483085444952,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36269657762507,
                    'lat': 30.524598383480438,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36116052494934,
                    'lat': 30.524090763787616,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35986181515833,
                    'lat': 30.52444776300722,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36380422219075,
                    'lat': 30.527261983998024,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36098975967525,
                    'lat': 30.529398208696783,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36210778060087,
                    'lat': 30.52421032304377,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36388827395625,
                    'lat': 30.526638912636034,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36386793296938,
                    'lat': 30.526360172627815,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36207773829724,
                    'lat': 30.5241742635061,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3624224198791,
                    'lat': 30.524285075860654,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36289521197065,
                    'lat': 30.528953109643005,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36403366424875,
                    'lat': 30.526902535639195,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36403366424875,
                    'lat': 30.526902535639195,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3585128953265,
                    'lat': 30.527688843045663,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36401849383195,
                    'lat': 30.527283324097258,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35875463610118,
                    'lat': 30.528296178985293,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35845599200537,
                    'lat': 30.525633817188186,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36407959178736,
                    'lat': 30.527527498245135,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36419373556164,
                    'lat': 30.527535677790464,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35934260490193,
                    'lat': 30.530156762047685,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35849543773803,
                    'lat': 30.53013434755327,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35811223823977,
                    'lat': 30.529038560752454,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36010653071311,
                    'lat': 30.528872598823213,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35841131806943,
                    'lat': 30.530098195227957,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35875463610118,
                    'lat': 30.528296178985293,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35890001894893,
                    'lat': 30.53039710743211,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35795282484133,
                    'lat': 30.528960782039256,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35782755316944,
                    'lat': 30.52937626319542,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35770826620846,
                    'lat': 30.529266743835606,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35769228841804,
                    'lat': 30.529779884738637,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35798312235846,
                    'lat': 30.528161544364142,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35909834081055,
                    'lat': 30.530965623114803,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35776280149274,
                    'lat': 30.528344759469952,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3585128953265,
                    'lat': 30.527688843045663,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36046616184211,
                    'lat': 30.530565740403034,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36098975967525,
                    'lat': 30.529398208696783,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35790641009194,
                    'lat': 30.52773357731755,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35721863108586,
                    'lat': 30.529877116684105,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35753546725581,
                    'lat': 30.52802849408139,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36054228696592,
                    'lat': 30.530830951471604,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35737184730725,
                    'lat': 30.52817037630066,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35979432302194,
                    'lat': 30.531342895925224,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35700529922858,
                    'lat': 30.529525640077235,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36112073472962,
                    'lat': 30.528478718223635,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35731624057067,
                    'lat': 30.52815297014707,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35730703945677,
                    'lat': 30.528152769135524,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36102492152742,
                    'lat': 30.528196005659858,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36080964372671,
                    'lat': 30.530823383629443,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35851058042007,
                    'lat': 30.53153483264828,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36113073619117,
                    'lat': 30.5281233187409,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36103142251726,
                    'lat': 30.52776420557798,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35769207481611,
                    'lat': 30.527325083943012,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35867082605155,
                    'lat': 30.53181219113422,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3610616267301,
                    'lat': 30.527594609000122,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35969423207898,
                    'lat': 30.531859901445227,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35694432261371,
                    'lat': 30.530787950175316,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35888694207468,
                    'lat': 30.531985895100618,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.357647382213,
                    'lat': 30.53158340095554,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35776280180195,
                    'lat': 30.526959756611596,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.3572184128884,
                    'lat': 30.527369298416428,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36160467079995,
                    'lat': 30.530523568864286,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35764698154865,
                    'lat': 30.52697889556942,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.36163471414093,
                    'lat': 30.530567631562917,
                    'bicycleType': 1,
                    'icon': ''
                },
                {
                    'carno': '6666',
                    'ordernum': '',
                    'userIdLast': '1',
                    'lng': 114.35620307171281,
                    'lat': 30.528529947853404,
                    'bicycleType': 1,
                    'icon': ''
                }
            ],
            'zoomLevel': 17
        }
    }
}";

        public static List<ofoInfo> ofoSampleList=new List<ofoInfo>();

        #endregion

        #region mobike示例数据

        public const string mobikesample = @"{
    'code': 0,
    'message': '',
    'biketype': 0,
    'autoZoom': true,
    'radius': 150,
    'object': [
        {
            'distId': '0250052342',
            'distX': 114.36052882,
            'distY': 30.52570326,
            'distNum': 1,
            'distance': '54',
            'bikeIds': '0250052342#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 100
        },
        {
            'distId': '0276572661',
            'distX': 114.36173343,
            'distY': 30.52583625,
            'distNum': 1,
            'distance': '67',
            'bikeIds': '0276572661#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620463132',
            'distX': 114.36146611,
            'distY': 30.52614492,
            'distNum': 1,
            'distance': '70',
            'bikeIds': '8620463132#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276515576',
            'distX': 114.36088523,
            'distY': 30.52485156,
            'distNum': 1,
            'distance': '85',
            'bikeIds': '0276515576#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620375740',
            'distX': 114.36045065,
            'distY': 30.52495389,
            'distNum': 1,
            'distance': '94',
            'bikeIds': '8620375740#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270021847',
            'distX': 114.36029544,
            'distY': 30.5248536,
            'distNum': 1,
            'distance': '112',
            'bikeIds': '0270021847#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276051996',
            'distX': 114.36102539,
            'distY': 30.52459171,
            'distNum': 1,
            'distance': '112',
            'bikeIds': '0276051996#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276595833',
            'distX': 114.36094628,
            'distY': 30.52452056,
            'distNum': 1,
            'distance': '120',
            'bikeIds': '0276595833#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621187399',
            'distX': 114.36017527,
            'distY': 30.5248294,
            'distNum': 1,
            'distance': '122',
            'bikeIds': '8621187399#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620780021',
            'distX': 114.36027639,
            'distY': 30.52467552,
            'distNum': 1,
            'distance': '128',
            'bikeIds': '8620780021#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276025266',
            'distX': 114.3609022,
            'distY': 30.52435043,
            'distNum': 1,
            'distance': '140',
            'bikeIds': '0276025266#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621167979',
            'distX': 114.3598168,
            'distY': 30.52493985,
            'distNum': 1,
            'distance': '141',
            'bikeIds': '8621167979#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270049011',
            'distX': 114.35995496,
            'distY': 30.524713,
            'distNum': 1,
            'distance': '146',
            'bikeIds': '0270049011#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270074818',
            'distX': 114.36046188,
            'distY': 30.52743971,
            'distNum': 1,
            'distance': '71',
            'bikeIds': '0270074818#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621087066',
            'distX': 114.36009542,
            'distY': 30.52773021,
            'distNum': 1,
            'distance': '80',
            'bikeIds': '8621087066#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620720080',
            'distX': 114.36003233,
            'distY': 30.5277031,
            'distNum': 1,
            'distance': '87',
            'bikeIds': '8620720080#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276026834',
            'distX': 114.36041697,
            'distY': 30.52908017,
            'distNum': 1,
            'distance': '132',
            'bikeIds': '0276026834#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8640090714',
            'distX': 114.36267383,
            'distY': 30.52782539,
            'distNum': 1,
            'distance': '171',
            'bikeIds': '8640090714#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276055743',
            'distX': 114.36261969,
            'distY': 30.52707406,
            'distNum': 1,
            'distance': '192',
            'bikeIds': '0276055743#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620637089',
            'distX': 114.36229947,
            'distY': 30.52929128,
            'distNum': 1,
            'distance': '200',
            'bikeIds': '8620637089#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620463132',
            'distX': 114.36146611,
            'distY': 30.52614492,
            'distNum': 1,
            'distance': '209',
            'bikeIds': '8620463132#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276031756',
            'distX': 114.36079456,
            'distY': 30.53009912,
            'distNum': 1,
            'distance': '238',
            'bikeIds': '0276031756#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276572661',
            'distX': 114.36173343,
            'distY': 30.52583625,
            'distNum': 1,
            'distance': '249',
            'bikeIds': '0276572661#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0250052342',
            'distX': 114.36052882,
            'distY': 30.52570326,
            'distNum': 1,
            'distance': '253',
            'bikeIds': '0250052342#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 100
        },
        {
            'distId': '0270032421',
            'distX': 114.36140541,
            'distY': 30.53056926,
            'distNum': 1,
            'distance': '45',
            'bikeIds': '0270032421#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8624013339',
            'distX': 114.36042313,
            'distY': 30.53090678,
            'distNum': 1,
            'distance': '57',
            'bikeIds': '8624013339#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276031756',
            'distX': 114.36079456,
            'distY': 30.53009912,
            'distNum': 1,
            'distance': '61',
            'bikeIds': '0276031756#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270079458',
            'distX': 114.36003654,
            'distY': 30.53002986,
            'distNum': 1,
            'distance': '110',
            'bikeIds': '0270079458#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620935768',
            'distX': 114.36031404,
            'distY': 30.53148479,
            'distNum': 1,
            'distance': '111',
            'bikeIds': '8620935768#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276544111',
            'distX': 114.36233664,
            'distY': 30.53069379,
            'distNum': 1,
            'distance': '134',
            'bikeIds': '0276544111#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276563873',
            'distX': 114.35953497,
            'distY': 30.53139249,
            'distNum': 1,
            'distance': '158',
            'bikeIds': '0276563873#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621167504',
            'distX': 114.36045228,
            'distY': 30.53214624,
            'distNum': 1,
            'distance': '173',
            'bikeIds': '8621167504#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276026834',
            'distX': 114.36041697,
            'distY': 30.52908017,
            'distNum': 1,
            'distance': '180',
            'bikeIds': '0276026834#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276044443',
            'distX': 114.35904829,
            'distY': 30.5311526,
            'distNum': 1,
            'distance': '189',
            'bikeIds': '0276044443#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '5746500547',
            'distX': 114.35894117,
            'distY': 30.53143852,
            'distNum': 1,
            'distance': '211',
            'bikeIds': '5746500547#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 100
        },
        {
            'distId': '0276577387',
            'distX': 114.3590283,
            'distY': 30.53161072,
            'distNum': 1,
            'distance': '212',
            'bikeIds': '0276577387#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270091852',
            'distX': 114.35841939,
            'distY': 30.53079044,
            'distNum': 1,
            'distance': '38',
            'bikeIds': '0270091852#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276044443',
            'distX': 114.35904829,
            'distY': 30.5311526,
            'distNum': 1,
            'distance': '51',
            'bikeIds': '0276044443#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '5746500547',
            'distX': 114.35894117,
            'distY': 30.53143852,
            'distNum': 1,
            'distance': '54',
            'bikeIds': '5746500547#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 100
        },
        {
            'distId': '8621021366',
            'distX': 114.35842849,
            'distY': 30.53176777,
            'distNum': 1,
            'distance': '72',
            'bikeIds': '8621021366#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276577387',
            'distX': 114.3590283,
            'distY': 30.53161072,
            'distNum': 1,
            'distance': '73',
            'bikeIds': '0276577387#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276563873',
            'distX': 114.35953497,
            'distY': 30.53139249,
            'distNum': 1,
            'distance': '102',
            'bikeIds': '0276563873#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620802408',
            'distX': 114.35761338,
            'distY': 30.53215153,
            'distNum': 1,
            'distance': '143',
            'bikeIds': '8620802408#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8608771531',
            'distX': 114.35807783,
            'distY': 30.52978954,
            'distNum': 1,
            'distance': '154',
            'bikeIds': '8608771531#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270091361',
            'distX': 114.35694429,
            'distY': 30.53038982,
            'distNum': 1,
            'distance': '171',
            'bikeIds': '0270091361#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276038196',
            'distX': 114.35724985,
            'distY': 30.53188383,
            'distNum': 1,
            'distance': '147',
            'bikeIds': '0276038196#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621036000',
            'distX': 114.35690035,
            'distY': 30.53183822,
            'distNum': 1,
            'distance': '173',
            'bikeIds': '8621036000#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276017801',
            'distX': 114.35715474,
            'distY': 30.53216776,
            'distNum': 1,
            'distance': '174',
            'bikeIds': '0276017801#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621770389',
            'distX': 114.35757102,
            'distY': 30.52865131,
            'distNum': 1,
            'distance': '25',
            'bikeIds': '8621770389#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270082834',
            'distX': 114.35786343,
            'distY': 30.52860479,
            'distNum': 1,
            'distance': '35',
            'bikeIds': '0270082834#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621162460',
            'distX': 114.3570323,
            'distY': 30.52914456,
            'distNum': 1,
            'distance': '67',
            'bikeIds': '8621162460#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276551071',
            'distX': 114.35747484,
            'distY': 30.52808897,
            'distNum': 1,
            'distance': '88',
            'bikeIds': '0276551071#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8608771531',
            'distX': 114.35807783,
            'distY': 30.52978954,
            'distNum': 1,
            'distance': '110',
            'bikeIds': '8608771531#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620575358',
            'distX': 114.35694122,
            'distY': 30.52964557,
            'distNum': 1,
            'distance': '110',
            'bikeIds': '8620575358#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276596708',
            'distX': 114.35703336,
            'distY': 30.52982178,
            'distNum': 1,
            'distance': '121',
            'bikeIds': '0276596708#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621451460',
            'distX': 114.35625013,
            'distY': 30.52841699,
            'distNum': 1,
            'distance': '143',
            'bikeIds': '8621451460#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8640083941',
            'distX': 114.35732751,
            'distY': 30.52666125,
            'distNum': 1,
            'distance': '39',
            'bikeIds': '8640083941#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276587047',
            'distX': 114.35771405,
            'distY': 30.52669992,
            'distNum': 1,
            'distance': '76',
            'bikeIds': '0276587047#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620551081',
            'distX': 114.35751271,
            'distY': 30.52600635,
            'distNum': 1,
            'distance': '78',
            'bikeIds': '8620551081#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276576780',
            'distX': 114.357025,
            'distY': 30.52580046,
            'distNum': 1,
            'distance': '80',
            'bikeIds': '0276576780#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620520515',
            'distX': 114.3570921,
            'distY': 30.52580758,
            'distNum': 1,
            'distance': '80',
            'bikeIds': '8620520515#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8642537395',
            'distX': 114.35754175,
            'distY': 30.5260014,
            'distNum': 1,
            'distance': '81',
            'bikeIds': '8642537395#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270055408',
            'distX': 114.35677277,
            'distY': 30.52726851,
            'distNum': 1,
            'distance': '84',
            'bikeIds': '0270055408#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8621187477',
            'distX': 114.35757978,
            'distY': 30.52576239,
            'distNum': 1,
            'distance': '103',
            'bikeIds': '8621187477#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8624010166',
            'distX': 114.35744959,
            'distY': 30.52566314,
            'distNum': 1,
            'distance': '106',
            'bikeIds': '8624010166#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620894128',
            'distX': 114.35757176,
            'distY': 30.52562333,
            'distNum': 1,
            'distance': '116',
            'bikeIds': '8620894128#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276599372',
            'distX': 114.35601068,
            'distY': 30.52718818,
            'distNum': 1,
            'distance': '116',
            'bikeIds': '0276599372#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276533388',
            'distX': 114.35686475,
            'distY': 30.52545908,
            'distNum': 1,
            'distance': '118',
            'bikeIds': '0276533388#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620637089',
            'distX': 114.36229947,
            'distY': 30.52929128,
            'distNum': 1,
            'distance': '66',
            'bikeIds': '8620637089#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276040293',
            'distX': 114.36384955,
            'distY': 30.53043009,
            'distNum': 1,
            'distance': '131',
            'bikeIds': '0276040293#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276544111',
            'distX': 114.36233664,
            'distY': 30.53069379,
            'distNum': 1,
            'distance': '136',
            'bikeIds': '0276544111#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620955013',
            'distX': 114.36438017,
            'distY': 30.52983872,
            'distNum': 1,
            'distance': '143',
            'bikeIds': '8620955013#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276572881',
            'distX': 114.36391947,
            'distY': 30.52847256,
            'distNum': 1,
            'distance': '155',
            'bikeIds': '0276572881#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620529698',
            'distX': 114.36411072,
            'distY': 30.52850587,
            'distNum': 1,
            'distance': '165',
            'bikeIds': '8620529698#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276546650',
            'distX': 114.36415878,
            'distY': 30.52852695,
            'distNum': 1,
            'distance': '166',
            'bikeIds': '0276546650#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0276505374',
            'distX': 114.36465947,
            'distY': 30.52932598,
            'distNum': 1,
            'distance': '169',
            'bikeIds': '0276505374#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '0270032421',
            'distX': 114.36140541,
            'distY': 30.53056926,
            'distNum': 1,
            'distance': '182',
            'bikeIds': '0270032421#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        },
        {
            'distId': '8620722182',
            'distX': 114.36384334,
            'distY': 30.52802229,
            'distNum': 1,
            'distance': '194',
            'bikeIds': '8620722182#',
            'biketype': 1,
            'type': 0,
            'boundary': null,
            'operateType': 1
        }
    ],
    'hasRedPacket': 0
}";
        public static List<mobikeInfo> mobikeSampleList=new List<mobikeInfo>();

        #endregion


        static SampleData()
        {
            //ofo示例数据初始化
            JObject ofoJObject = JObject.Parse(ofosample);
            string jarry1 = (((ofoJObject["values"])["info"])["cars"]).ToString();
            ofoSampleList = JsonConvert.DeserializeObject<List<ofoInfo>>(jarry1);

            //mobike示例数据初始化
            JObject mobikeJObject = JObject.Parse(mobikesample);
            string jarry2 = mobikeJObject["object"].ToString();
            mobikeSampleList = JsonConvert.DeserializeObject<List<mobikeInfo>>(jarry2);
        }


    }
}
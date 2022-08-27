using System.Drawing;
using Services.Contracts;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.Diagnostics;

namespace Services.Services
{
    public class AiService : IAiService
    {
        // variables
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier
            (Directory.GetCurrentDirectory() 
            + @"\..\Services\Services\haarcascade_frontalface_alt.xml");

        Image<Bgr, Byte> faceResult = null;

        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();

        EigenFaceRecognizer recognizer;

        // upload image
        public bool UploadImage(string name, string data, string localPath)
        {
            var t = data.Substring(31); // remove data:image/png;base64,
            byte[] bytes = Convert.FromBase64String(t);
            // save image
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            var fileName = name + ".png";
            // folder for training image
            Directory.CreateDirectory(localPath + "/Images/" + name);
            var fullPath = Path.Combine(localPath + "/Images/" + name, fileName);
            //var fullPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            DetectFace(name, fileName, localPath);
            TrainImagesFromDir();
            return RecognizeFace();
        }

        // register image
        public bool RegisterImage(string name, string data, string localPath)
        {
            var t = data.Substring(31); // remove data:image/png;base64,
            byte[] bytes = Convert.FromBase64String(t);
            // save image
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            var fileName = name + ".png";
            // folder for training image
            Directory.CreateDirectory(localPath + "/Images/" + name);
            var fullPath = Path.Combine(localPath + "/Images/" + name, fileName);
            //var fullPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            DetectFace(name, fileName, localPath);
            return TrainImagesFromDir();
        }

        // detect face in image
        private void DetectFace(string name, string fileName, string localPath)
        {
            string pathFileImage = Path.Combine(localPath + "/Images/" + name, fileName);
            currentFrame = new Image<Bgr, byte>(pathFileImage).Resize(700, 500, Inter.Cubic);

            //Convert from Bgr to Gray Image
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
            //Enhance the image to get better result
            CvInvoke.EqualizeHist(grayImage, grayImage);
            // detect face
            Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
            if (faces.Length > 0)
            {
                foreach (var face in faces)
                {
                    //We will create a directory if does not exists!
                    string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    resultImage.ROI = face;
                    //resize the image then saving it
                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + name
                            + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".png");
                }
            }
        }

        // train Images .. we will use the saved images from the previous example 
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                // get all images files
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(">>> train " + ImagesCount + ". " + name);
                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);

                    Image<Gray, byte>[] trainedImage = TrainedFaces.ToArray();
                    int[] personLabes = PersonsLabes.ToArray();
                    List<Mat> mats = new List<Mat>();
                    for (int i = 0; i < trainedImage.Length; i++)
                    {
                        mats.Add(trainedImage[i].Mat);
                    }
                    mats.ToArray();

                    recognizer.Train(mats.ToArray(), personLabes);
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Train Images: " + ex.Message);
                return false;
            }

        }

        // recognize face
        private bool RecognizeFace()
        {
            Debug.WriteLine("recognize");
            //int ImagesCount = 0;
            //double Threshold = 2000;
            // get all images files
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
            // ImagesCount = files.Count();
            // recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);

            Image<Gray, Byte> grayFaceResult = new Image<Gray, byte>(files[3])
                .Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);

            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
            var result = recognizer.Predict(grayFaceResult);

            Debug.WriteLine("recognize " + result.Label + ". " + result.Distance);
            //Here results found known faces
            if (result.Label != -1 && result.Distance < 2000)
            {
                Debug.WriteLine("found face");
                return true;
            }
            //here results did not found any know faces
            else
            {
                Debug.WriteLine("not found face");
                return false;

            }
        }
    }
}
